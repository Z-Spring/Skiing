using UnityEngine;

namespace Skiing2
{
    // 如果要生成的物体很多，可以使用抽象的工厂方法，避免这个文件后面越来越大
    public static class GameFactory
    {
        public static PlayerEntity SpawnPlayer(AssetsInfraContext assetsInfraContext,
            TemplateInfraContext templateInfraContext, Vector2 position)
        {
            var config = templateInfraContext.GameConfig;
            var prefab = assetsInfraContext.GetPlayer();
            var player = GameObject.Instantiate(prefab).GetComponent<PlayerEntity>();

            player.SetPlayerSpeed(config.xSpeed, config.ySpeed);
            player.SetPlayerDynamicSpeed(config.acceleration, config.deceleration);
            player.SetPlayerPosition(position);

            player.Ctor();

            var playerCom = player.PlayerComponent;
            playerCom.SetColor(RandomColor.SetRandomColor(), RandomColor.SetRandomColor());
            
            var fsmCom = player.GetPlayerFsmComponent();
            fsmCom.EnterIdle();

            return player;
        }

        public static EnemyEntity SpawnSlime(AssetsInfraContext assetsInfraContext,
            TemplateInfraContext templateInfraContext, Vector2 position)
        {
            var config = templateInfraContext.GameConfig;
            var slime = SlimePool.GetSlimeFromPool().GetComponent<EnemyEntity>();
            slime.SetScore(config.highScore, config.middleScore, config.lowScore);
            slime.SetRadius(config.highScoreRadius, config.middleScoreRadius, config.lowScoreRadius,
                config.colliderRadius);
            slime.SetPosition(position);

            return slime;
        }


        public static FinishLineEntity SpawnFinishLine(AssetsInfraContext assetsInfraContext,
            TemplateInfraContext templateInfraContext, Vector2 position)
        {
            var config = templateInfraContext.GameConfig;
            var prefab = assetsInfraContext.GetFinishLine();
            var finishLine = GameObject.Instantiate(prefab).GetComponent<FinishLineEntity>();

            finishLine.SetPosition(position);

            return finishLine;
        }

       
    }
}