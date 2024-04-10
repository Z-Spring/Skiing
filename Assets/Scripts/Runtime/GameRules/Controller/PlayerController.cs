using UnityEngine;

namespace Skiing2.GameRules.Game
{
    public class PlayerController
    {
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Slime"))
            {
                // Dead();
            }
        }

        public void Tick(GameBusinessContext ctx)
        {
            PlayerDomain.MoveControl(ctx);
        }
    }
}