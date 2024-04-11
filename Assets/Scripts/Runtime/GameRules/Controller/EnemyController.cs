namespace Skiing2.GameRules.Game
{
    public class EnemyController
    {
        public void Init(GameBusinessContext ctx)
        {
            ctx.monoBehaviour.StartCoroutine(EnemyDomain.CheckIfSpawnSlime(ctx));
        }

        public void Tick(GameBusinessContext ctx)
        {
            var game = ctx.gameEntity;
            var fsm = game.GameFSMComponent;
            var status = fsm.state;
            if (status != GameState.Playing) return;

            EnemyDomain.CollisionDetection(ctx);
        }
    }
}