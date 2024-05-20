using System.Collections;
using System.Collections.Generic;
using Skiing2.Sound;
using UnityEngine;

namespace Skiing2.GameRules.Game
{
    public static class EnemyDomain
    {
        public static List<EnemyEntity> SpawnEnemy(GameBusinessContext ctx, Vector2 offset)
        {
            for (int i = 0; i < ctx.startSlimeCount; i++)
            {
                var pos = Random.insideUnitCircle * ctx.mainCamera.orthographicSize - offset;
                var enemy = GameFactory.SpawnSlime(ctx.assetsInfraContext, ctx.templateInfraContext, pos);

                ctx.enemies.Add(enemy);
            }

            return ctx.enemies;
        }

        public static void DestroyEnemy(GameBusinessContext ctx)
        {
            ctx.enemies.Clear();
            ctx.enemies.ForEach(e => e.TearDown());
        }

        public static void CollisionDetection(GameBusinessContext ctx)
        {
            var slimes = ctx.enemies;
            var playerLayer = ctx.playerLayer;

            var highScoreRadius = slimes[0].HighScoreRadius;
            var middleScoreRadius = slimes[0].MiddleScoreRadius;
            var lowScoreRadius = slimes[0].LowScoreRadius;
            var colliderRadius = slimes[0].ColliderRadius;

            foreach (var slime in slimes)
            {
                if (Physics2D.OverlapCircle(slime.transform.position, colliderRadius, playerLayer))
                {
                    SkiingLog.Log("collider!");
                    GameEventCenter.FailGame(ctx);
                    SoundDomain.PlaySound(ctx.soundContext, SoundType.Dead);
                }
                else if (Physics2D.OverlapCircle(slime.transform.position, lowScoreRadius, playerLayer))
                {
                    SkiingLog.Log("Low Score!");
                    SoundDomain.PlaySound(ctx.soundContext, SoundType.Perfect);
                }
                else if (Physics2D.OverlapCircle(slime.transform.position, middleScoreRadius, playerLayer))
                {
                    SkiingLog.Log("Middle Score!");
                    SoundDomain.PlaySound(ctx.soundContext, SoundType.Perfect);
                }
                else if (Physics2D.OverlapCircle(slime.transform.position, highScoreRadius, playerLayer))
                {
                    SkiingLog.Log("High Score!");
                    SoundDomain.PlaySound(ctx.soundContext, SoundType.Fever);
                }
            }
        }

        public static void VisibilityCheck(GameBusinessContext ctx)
        {
            var slimes = ctx.enemies;
            var slimesToRemove = ctx.slimesToRemove;
            slimesToRemove.Clear();
            
            foreach (var slime in slimes)
            {
                Vector3 viewportPoint = ctx.mainCamera.WorldToViewportPoint(slime.transform.position);

                bool isAboveViewport = viewportPoint.y > 1;
                bool isLeftViewport = viewportPoint.x < 0;
                bool isRightViewport = viewportPoint.x > 1;
                bool isAboveZero = slime.transform.position.y > 0;
                bool isBelowFinishLine = slime.transform.position.y < ctx.FinishLineEntity.transform.position.y;
                if (isLeftViewport || isRightViewport || isAboveZero || isBelowFinishLine)
                {
                    SlimePool.ReturnSlime(slime.gameObject);
                    slimesToRemove.Add(slime);
                }
            }

            ctx.enemies.RemoveAll(s => slimesToRemove.Contains(s));
        }

        public static IEnumerator CheckIfSpawnSlime(GameBusinessContext ctx)
        {
            var mainCamera = ctx.mainCamera;
            var cameraHeight = mainCamera.orthographicSize * 2;
            var round = 1;
            var nextSpawnY = ctx.nextSpawnY;
            while (true)
            {
                if (mainCamera.transform.position.y <= nextSpawnY + 2)
                {
                    round++;
                    var positionBelowCamera = new Vector2(0, cameraHeight * round);
                    SpawnEnemy(ctx, positionBelowCamera);
                    VisibilityCheck(ctx);
                    nextSpawnY -= cameraHeight;
                }

                yield return null;
            }
        }
    }
}