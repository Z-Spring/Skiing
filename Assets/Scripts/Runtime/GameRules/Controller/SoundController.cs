namespace Skiing2.GameRules.Game
{
    public class SoundController
    {
        public void Tick()
        {
            // Play sound
        }

        public void PlaySound(GameBusinessContext ctx, SoundType soundType)
        {
            // Play sound
            SoundDomain.PlaySound(ctx, soundType);
        }

        public void StopSound(GameBusinessContext ctx)
        {
            // Stop sound
        }
    }
}