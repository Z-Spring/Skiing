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
            player.TearDown();
        }

        public static void MoveControl(GameBusinessContext ctx)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }

                ctx.isTurnAround = !ctx.isTurnAround;
                ctx.isMoving = true;
            }

            if (ctx.isMoving)
            {
                Move(ctx);
                CheckIfWinGame();
                OutOfBoundsJudgement(ctx, ctx.background);
            }
        }

        static void Move(GameBusinessContext ctx)
        {
            var player = ctx.PlayerEntity;

            if (!ctx.isMoving) return;

            float targetSpeed = ctx.direction * player.GetPlayerXMoveSpeed();
            ctx.currentSpeed = Mathf.MoveTowards(ctx.currentSpeed, targetSpeed,
                player.GetPlayerAcceleration() * Time.deltaTime);
            if (ctx.isTurnAround != ctx.lastTurnAroundState)
            {
                ctx.direction = ctx.isTurnAround ? -1 : 1;
                ctx.lastTurnAroundState = ctx.isTurnAround;
            }


            ctx.rb.velocity = new Vector2(ctx.currentSpeed, -player.GetPlayerYMoveSpeed());
        }

        static void OutOfBoundsJudgement(GameBusinessContext ctx, GameObject background)
        {
            if (ctx.PlayerEntity.transform.position.x >=
                background.transform.position.x + background.transform.localScale.x / 2 ||
                ctx.PlayerEntity.transform.position.x <=
                background.transform.position.x - background.transform.localScale.x / 2)
            {
                Dead(ctx);
            }
        }

        static void CheckIfWinGame()
        {
            /*Vector3 finishLinePos = FinishLineUI.Instance.FinishLinePosition;
            if (transform.position.y <= finishLinePos.y)
            {
                EventCenter.WinGame();
                EventCenter.EffectPlay(EffectType.Confetti);
                EventCenter.PlaySound(SoundType.LevelUp);
                GameManager.Instance.SetGameState(GameState.Win);
                EventCenter.PlayCrossFade(CrossFadeType.NextLevel);
                isMoving = false;
                rb.velocity = new Vector2(currentXSpeed, -yMoveSpeed);
                Destroy(gameObject, 2f);

                print("win!");
            }

            processBarValue = (transform.position.y - GameManager.Instance.PlayerInitPosition.y) /
                              (finishLinePos.y - GameManager.Instance.PlayerInitPosition.y);
            EventCenter.ProgressChange(ProgressBarType.Current, processBarValue);*/
        }

        static void Dead(GameBusinessContext ctx)
        {
            Debug.Log("game over!");
            DestroyPlayer(ctx, ctx.PlayerEntity);
        }
    }
}