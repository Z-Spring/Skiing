namespace Skiing2
{
    public class GameEntity
    {
        GameFSMComponent gameFSMComponent;

        public GameEntity()
        {
            gameFSMComponent = new GameFSMComponent();
        }
        
        public GameFSMComponent GameFSMComponent => gameFSMComponent;
    }
}