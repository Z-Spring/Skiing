using UnityEngine;

namespace Skiing2.GameRules.Game
{
    public static class GameDomain
    {
        public static void StartGame(GameBusinessContext ctx)
        {
            // player
            var playerPos = new Vector2(0, 4);
            var player = PlayerDomain.SpawnPlayer(ctx, playerPos);
            ctx.playerTrail.position = playerPos;
            ctx.playerTrail.GetComponent<TrailRenderer>().Clear();

            // finish line
            var finishLineY = ctx.templateInfraContext.GameConfig.finishLineY;
            var pos = player.transform.position - new Vector3(0, finishLineY, 0);
            FinishLineDomain.SpawnFinishLine(ctx, pos);
            ctx.confettiEffect.transform.position = pos;

            // enemy
            EnemyDomain.SpawnEnemy(ctx, new Vector2(0, 0));
            EnemyDomain.SpawnEnemy(ctx, new Vector2(0, ctx.mainCamera.orthographicSize * 2));
            EnemyDomain.VisibilityCheck(ctx);

            // sound
            SoundDomain.SpawnSound(ctx);

            // game
            var game = ctx.gameEntity;
            var gameFsm = game.GameFSMComponent;
            gameFsm.EnterGame();

            {
                ctx.followCamera.Follow = player.transform;
                var rb = player.GetRigidbody2D();
                rb.velocity = Vector2.zero;
                ctx.rb = rb;
            }
        }

        public static void EndGame(GameBusinessContext ctx)
        {
            var game = ctx.gameEntity;
            var gameFsm = game.GameFSMComponent;
            gameFsm.ExitGame();


            var player = ctx.PlayerEntity;
            var finishLine = ctx.FinishLineEntity;

            PlayerDomain.DestroyPlayer(ctx, player);
            EnemyDomain.DestroyEnemy(ctx);
            FinishLineDomain.DestroyFinishLine(ctx, finishLine);
            SoundDomain.DestroySound(ctx);
            SlimePool.TearDown();
        }

        public static void RestartGame(GameBusinessContext ctx)
        {
            EndGame(ctx);
            StartGame(ctx);
        }

        public static void WinGame(GameBusinessContext ctx)
        {
            /*Vector3 finishLinePos = FinishLineUI.Instance.FinishLinePosition;
           if (transform.position.y <= finishLinePos.y)
           {
               EventCenter.PlaySound(SoundType.LevelUp);
               EventCenter.PlayCrossFade(CrossFadeType.NextLevel);
               rb.velocity = new Vector2(currentXSpeed, -yMoveSpeed);

           }

           processBarValue = (transform.position.y - GameManager.Instance.PlayerInitPosition.y) /
                             (finishLinePos.y - GameManager.Instance.PlayerInitPosition.y);
           EventCenter.ProgressChange(ProgressBarType.Current, processBarValue);*/

            var game = ctx.gameEntity;
            var gameFsm = game.GameFSMComponent;
            gameFsm.WinGame();

            ctx.followCamera.Follow = null;
            EffectService.PlayConfettiEffect(ctx);
            SoundDomain.PlaySound(ctx, SoundType.LevelUp);

            SkiingLog.Log("win");
        }

        public static void FailGame(GameBusinessContext ctx)
        {
            var game = ctx.gameEntity;
            var gameFsm = game.GameFSMComponent;
            gameFsm.FailGame();

            var player = ctx.PlayerEntity;

            PlayerDomain.DestroyPlayer(ctx, player);
            SoundDomain.PlaySound(ctx, SoundType.Dead);

            SkiingLog.Log("lose");
        }

        // todo: temp solution
        public static void PlaySound(GameBusinessContext ctx)
        {
            // Play sound
            SoundDomain.PlaySound(ctx);
        }
    }
}