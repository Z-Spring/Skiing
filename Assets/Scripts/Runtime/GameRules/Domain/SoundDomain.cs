using UnityEngine;

namespace Skiing2.GameRules.Game
{
    public static class SoundDomain
    {
        public static SoundEntity SpawnSound(GameBusinessContext ctx)
        {
            var sound = GameFactory.SpawnSound(ctx.assetsInfraContext, ctx.templateInfraContext);
            ctx.SoundEntity = sound;
            return sound;
        }

        public static void DestroySound(GameBusinessContext ctx)
        {
            ctx.SoundEntity = null;
        }

        public static void PlaySound(GameBusinessContext ctx, SoundType soundType = SoundType.None)
        {
            if (!ctx.isPlaySound) return;
            switch (soundType)
            {
                case SoundType.Dead:
                    PlaySound(ctx, ctx.SoundEntity.Dead);
                    break;
                case SoundType.Fever:
                    PlaySound(ctx, ctx.SoundEntity.Fever);
                    break;
                case SoundType.LevelUp:
                    PlaySound(ctx, ctx.SoundEntity.LevelUp);
                    break;
                case SoundType.Ski:
                    PlaySound(ctx, ctx.SoundEntity.Ski, 0.01f);
                    break;
                case SoundType.Perfect:
                    PlaySound(ctx, ctx.SoundEntity.Perfect);
                    break;
                case SoundType.None:
                    break;
            }
        }

        static void PlaySound(GameBusinessContext ctx, AudioClip clip, float volume = 1)
        {
            var soundEntity = ctx.SoundEntity;
            soundEntity.AudioSource.PlayOneShot(clip, volume);
        }
    }
}