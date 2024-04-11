namespace Skiing2
{
    public class PlayerFSMComponent
    {
        public PlayerState playerState;

        public void EnterIdle()
        {
            playerState = PlayerState.Idle;
        }

        public void EnterDead()
        {
            playerState = PlayerState.Dead;
        }

        public void EnterRevive()
        {
            playerState = PlayerState.Revive;
        }
    }
}