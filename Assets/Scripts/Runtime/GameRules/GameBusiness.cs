namespace Skiing2.GameRules.Game
{
    public static class GameBusiness
    {
        public static void StartGame(GameBusinessContext ctx)
        {
            // Start the game
            GameDomain.StartGame(ctx);
        }
        
        public static void EndGame(GameBusinessContext ctx)
        {
            // End the game
            GameDomain.EndGame(ctx);
        }
        
        public static void TearDown(GameBusinessContext ctx)
        {
            EndGame(ctx);
        }
    }
}