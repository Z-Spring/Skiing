using UnityEngine;
using UnityEngine.Assertions;

namespace Skiing2.Sound
{
    public static class SoundDomain
    {
        public static SoundEntity SpawnSound(SoundContext ctx)
        {
            var sound = SoundFactory.SpawnSound(ctx.assetsInfraContext, ctx.templateInfraContext);
            ctx.SoundEntity = sound;
            return sound;
        }

        public static void DestroySound(SoundContext ctx)
        {
            ctx.SoundEntity = null;
        }

        public static void PlaySound(SoundContext ctx, SoundType soundType = SoundType.None)
        {
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

        public static void StopSound(SoundContext ctx)
        {
            var soundEntity = ctx.SoundEntity;

            soundEntity.AudioSource.enabled = false;
        }

        static void PlaySound(SoundContext ctx, AudioClip clip, float volume = 1)
        {
            var soundEntity = ctx.SoundEntity;
            soundEntity.AudioSource.PlayOneShot(clip, volume);
        }
    }
}