using UnityEngine;

namespace Skiing2.GameRules.Game
{
    public static class GameDomain
    {
        public static void StartGame(GameBusinessContext ctx)
        {
            var player = PlayerDomain.SpawnPlayer(ctx, new Vector2(0, 4));
            var enemy = EnemyDomain.SpawnEnemy(ctx, new Vector2(0, 0));

            var game = ctx.gameEntity;
            var gameFsm = game.GameFSMComponent;
            gameFsm.EnterGame();

            {
                var finishLineY = ctx.templateInfraContext.GameConfig.finishLineY;
                var pos = player.transform.position - new Vector3(0, finishLineY, 0);
                FinishLineDomain.SpawnFinishLine(ctx, pos);
            }


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
            var enemy = ctx.EnemyEntity;
            var finishLine = ctx.FinishLineEntity;

            PlayerDomain.DestroyPlayer(ctx, player);
            EnemyDomain.DestroyEnemy(ctx, enemy);
            finishLine.TearDown();
        }
    }
}