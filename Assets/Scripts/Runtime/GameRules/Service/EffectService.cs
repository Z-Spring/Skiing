namespace Skiing2.GameRules.Game
{
    public static class EffectService
    {
        public static void PlayFlareEffect(GameBusinessContext ctx)
        {
            ctx.flareEffect.Play();
        }

        public static void PlaySmokeEffect(GameBusinessContext ctx)
        {
            // Play effect
            ctx.smokeEffect.Play();
        }

        public static void PlayConfettiEffect(GameBusinessContext ctx)
        {
            ctx.confettiEffect.Play();
        }


        public static void PlayEffect(GameBusinessContext ctx)
        {
            // Play effect
        }

        public static void StopEffect()
        {
            // Stop effect
        }
    }
}