namespace Skiing2.GameRules.Game
{
    public class EnemyController
    {
        public void Tick(GameBusinessContext ctx)
        {
            EnemyDomain.CollisionDetection(ctx);
            EnemyDomain.VisibilityCheck(ctx);
        }
    }
}