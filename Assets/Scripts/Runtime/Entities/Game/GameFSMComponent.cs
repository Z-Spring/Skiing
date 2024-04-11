namespace Skiing2
{
    public class GameFSMComponent
    {
        public GameState state;

        public void EnterGame()
        {
            state = GameState.Start;
        }

        public void ExitGame()
        {
            state = GameState.GameOver;
        }

        public void RestartGame()
        {
            state = GameState.Restart;
        }

        public void PlayGame()
        {
            state = GameState.Playing;
        }
        
        public void FailGame()
        {
            state = GameState.Fail;
        }

        public void WinGame()
        {
            state = GameState.Win;
        }
    }
}