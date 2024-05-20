using UnityEngine;

namespace Skiing2.Sound
{
    public static class SoundFactory
    {
        public static SoundEntity SpawnSound(AssetsInfraContext assetsInfraContext,
            TemplateInfraContext templateInfraContext)
        {
            var config = templateInfraContext.GameConfig;
            var prefab = assetsInfraContext.GetSound();
            var sound = GameObject.Instantiate(prefab).GetComponent<SoundEntity>();

            sound.AudioSource = sound.GetComponent<AudioSource>();
            sound.Dead = config.dead;
            sound.Fever = config.fever;
            sound.LevelUp = config.levelUp;
            sound.Ski = config.ski;
            sound.Perfect = config.perfect;

            return sound;
        }
    }
}