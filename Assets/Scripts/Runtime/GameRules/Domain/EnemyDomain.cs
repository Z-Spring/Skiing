using UnityEngine;

namespace Skiing2.GameRules.Game
{
    public static class EnemyDomain
    {
        public static EnemyEntity SpawnEnemy(GameBusinessContext ctx, Vector2 position)
        {
            var enemy = GameFactory.SpawnSlime(ctx.assetsInfraContext, ctx.templateInfraContext, position);
            ctx.EnemyEntity = enemy;
            return enemy;
        }

        public static void DestroyEnemy(GameBusinessContext ctx, EnemyEntity enemy)
        {
            ctx.EnemyEntity = null;
            enemy.TearDown();
        }

        public static void CollisionDetection(GameBusinessContext ctx)
        {
            var slime = ctx.EnemyEntity;
            var playerLayer = ctx.playerLayer;

            var highScoreRadius = ctx.templateInfraContext.GameConfig.highScoreRadius;
            var middleScoreRadius = ctx.templateInfraContext.GameConfig.middleScoreRadius;
            var lowScoreRadius = ctx.templateInfraContext.GameConfig.lowScoreRadius;

            if (Physics2D.OverlapCircle(slime.transform.position, highScoreRadius, playerLayer))
            {
                Debug.Log("High Score!");
            }
            else if (Physics2D.OverlapCircle(slime.transform.position, middleScoreRadius, playerLayer))
            {
                Debug.Log("Middle Score!");
            }
            else if (Physics2D.OverlapCircle(slime.transform.position, lowScoreRadius, playerLayer))
            {
                Debug.Log("Low Score!");
            }
        }

        public static void VisibilityCheck(GameBusinessContext ctx)
        {
            var player = ctx.PlayerEntity;

            Vector3 viewportPoint = ctx.mainCamera.WorldToViewportPoint(player.transform.position);

            bool isAboveViewport = viewportPoint.y > 1;
            bool isLeftViewport = viewportPoint.x < 0;
            bool isRightViewport = viewportPoint.x > 1;
            bool isAboveZero = player.transform.position.y > 0;
            // bool isBelowFinishLine = transform.position.y < FinishLineUI.Instance.FinishLinePosition.y;
            if (isLeftViewport || isRightViewport || isAboveZero)
            {
                Debug.Log("return slime!");
                // SlimePool.Instance.ReturnSlime(gameObject);
            }
        }
    }
}