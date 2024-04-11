namespace Skiing2.GameRules.Game
{
    public class PlayerController
    {
        public void Tick(GameBusinessContext ctx)
        {
            var game = ctx.gameEntity;
            var fsm = game.GameFSMComponent;
            var status = fsm.state;

            if (status == GameState.Start || status == GameState.Playing)
            {
                PlayerDomain.MoveControl(ctx);
                if (ctx.isMoving)
                {
                    if (PlayerDomain.OutOfBounds(ctx))
                    {
                        GameEventCenter.FailGame(ctx);
                    }
                    else if (PlayerDomain.WinGame(ctx))
                    {
                        GameEventCenter.WinGame(ctx);
                    }
                }
            }

            if (status != GameState.None && status != GameState.GameOver && status != GameState.Fail)
            {
                PlayerDomain.UpdatePlayerTrial(ctx);
            }
        }

        public void FixedTick(GameBusinessContext ctx)
        {
            var game = ctx.gameEntity;
            var fsm = game.GameFSMComponent;
            var status = fsm.state;

            if (ctx.isMoving && status == GameState.Playing)
            {
                PlayerDomain.Move(ctx);
            }
        }
    }
}