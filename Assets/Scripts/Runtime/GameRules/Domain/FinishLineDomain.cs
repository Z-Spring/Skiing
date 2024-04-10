using UnityEngine;

namespace Skiing2.GameRules.Game
{
    public static class FinishLineDomain
    {
        public static FinishLineEntity SpawnFinishLine(GameBusinessContext ctx, Vector2 position)
        {
            var finishLine = GameFactory.SpawnFinishLine(ctx.assetsInfraContext, ctx.templateInfraContext, position);
            ctx.FinishLineEntity = finishLine;
            return finishLine;
        }
    }
}