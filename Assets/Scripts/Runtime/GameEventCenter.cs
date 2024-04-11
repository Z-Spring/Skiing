using System;
using Skiing2.GameRules.Game;

namespace Skiing2
{
    public static class GameEventCenter
    {
        public static event Action<GameBusinessContext> OnWinGame;
        public static event Action<GameBusinessContext> OnFailGame;
        
        public static void WinGame(GameBusinessContext ctx)
        {
            OnWinGame?.Invoke(ctx);
        }
        
        public static void FailGame(GameBusinessContext ctx)
        {
            OnFailGame?.Invoke(ctx);
        }
    }
}