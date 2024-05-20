using UnityEngine;

namespace Skiing2.GameRules.Game
{
    public static class GameBusiness
    {
        public static void Init(GameBusinessContext ctx)
        {
            SlimePool.slimePrefab = ctx.assetsInfraContext.GetSlime();
            SlimePool.parent = ctx.slimeParent;
            SlimePool.InitPool(ctx.templateInfraContext.GameConfig.initSlimeNum);
        }

        public static void StartGame(GameBusinessContext ctx)
        {
            // Start the game
            GameDomain.StartGame(ctx);
        }

        public static void WinGame(GameBusinessContext ctx)
        {
            // Win the game
            GameDomain.WinGame(ctx);
        }

        public static void FailGame(GameBusinessContext ctx)
        {
            // Fail the game
            GameDomain.FailGame(ctx);
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

        /*public static void PlaySound(GameBusinessContext ctx)
        {
            var audioSource = ctx.Bgm.GetComponent<AudioSource>();
            // Play sound
            if (ctx.isPlaySound)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }

            GameDomain.PlaySound(ctx);
        }*/
    }
}