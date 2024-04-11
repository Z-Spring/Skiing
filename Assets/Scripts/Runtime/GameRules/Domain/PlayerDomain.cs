using UnityEngine;
using UnityEngine.EventSystems;

namespace Skiing2.GameRules.Game
{
    public static class PlayerDomain
    {
        public static PlayerEntity SpawnPlayer(GameBusinessContext ctx, Vector2 position)
        {
            var player = GameFactory.SpawnPlayer(ctx.assetsInfraContext, ctx.templateInfraContext, position);
            ctx.PlayerEntity = player;
            return player;
        }

        public static void DestroyPlayer(GameBusinessContext ctx, PlayerEntity player)
        {
            ctx.PlayerEntity = null;
            if (player == null) return;
            player.TearDown();
        }

        public static void MoveControl(GameBusinessContext ctx)
        {
            var game = ctx.gameEntity;
            var fsm = game.GameFSMComponent;

            if (Input.GetMouseButtonDown(0))
            {
                if (!ctx.isStartGame)
                {
                    if (EventSystem.current.IsPointerOverGameObject()) return;
                    ctx.isStartGame = true;
                    fsm.PlayGame();
                    ctx.isMoving = true;
                }

                ctx.isTurnAround = !ctx.isTurnAround;
                SoundDomain.PlaySound(ctx, SoundType.Ski);
                if (ctx.isTurnAround != ctx.lastTurnAroundState)
                {
                    ctx.direction = ctx.isTurnAround ? -1 : 1;
                    ctx.lastTurnAroundState = ctx.isTurnAround;
                    ChangeFeetDirection(ctx, ctx.direction);
                }
            }
        }

        public static void Move(GameBusinessContext ctx)
        {
            var player = ctx.PlayerEntity;

            if (!ctx.isMoving) return;

            float targetSpeed = ctx.direction * player.GetPlayerXMoveSpeed();
            ctx.currentSpeed = Mathf.MoveTowards(ctx.currentSpeed, targetSpeed,
                player.GetPlayerAcceleration() * Time.deltaTime);


            ctx.rb.velocity = new Vector2(ctx.currentSpeed, -player.GetPlayerYMoveSpeed());
        }

        public static bool OutOfBounds(GameBusinessContext ctx)
        {
            var background = ctx.background;
            if (ctx.PlayerEntity.transform.position.x >=
                background.transform.position.x + background.transform.localScale.x / 2 ||
                ctx.PlayerEntity.transform.position.x <=
                background.transform.position.x - background.transform.localScale.x / 2)
            {
                return true;
            }

            return false;
        }

        public static bool WinGame(GameBusinessContext ctx)
        {
            var finishLinePos = ctx.FinishLineEntity.transform.position;
            if (ctx.PlayerEntity.transform.position.y <= finishLinePos.y)
            {
                return true;
            }

            return false;
        }

        public static void UpdatePlayerTrial(GameBusinessContext ctx)
        {
            if (ctx.PlayerEntity == null) return;
            ctx.playerTrail.position = ctx.PlayerEntity.transform.position;
        }

        static void ChangeFeetDirection(GameBusinessContext ctx, int direction)
        {
            var feet = ctx.PlayerEntity.GetPlayerFeet();
            var feetScale = feet.localScale;

            feet.localScale = new Vector3(direction * Mathf.Abs(feetScale.x), feetScale.y, feetScale.z);
        }
    }
}