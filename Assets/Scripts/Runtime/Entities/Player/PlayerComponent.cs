using UnityEngine;

namespace Skiing2
{
    public class PlayerComponent
    {
        Transform playerBody;
        Transform playerHat;
        public Transform playerFeet;
        public Transform playerTrail;

        public PlayerComponent(Transform playerBody, Transform playerHat)
        {
            this.playerBody = playerBody;
            this.playerHat = playerHat;
        }

        public void SetColor(Color bodyColor, Color hatColor)
        {
            playerBody.GetComponent<SpriteRenderer>().color = bodyColor;
            playerHat.GetComponent<SpriteRenderer>().color = hatColor;
        }
    }
}