using UnityEngine;

namespace Skiing2
{
    public class PlayerEntity : MonoBehaviour
    {
        // set movement
        float xMoveSpeed;
        float yMoveSpeed;
        float acceleration;
        float deceleration;

        Color playerBodyColor;
        Color playerHatColor;

        Rigidbody2D rb;
        Transform playerBody;
        Transform playerHat;

        // Fsm
        PlayerFSMComponent playerFsmComponent;

        public void Ctor()
        {
            playerFsmComponent = new PlayerFSMComponent();
            
            rb = GetComponent<Rigidbody2D>();
            playerBody = transform.GetChild(0);
            playerHat = transform.GetChild(1);
            playerBody.GetComponent<SpriteRenderer>().color = playerBodyColor;
            playerHat.GetComponent<SpriteRenderer>().color = playerHatColor;
        }

        // setter and getter
        public void SetPlayerSpeed(float xSpeed, float ySpeed)
        {
            xMoveSpeed = xSpeed;
            yMoveSpeed = ySpeed;
        }

        public void SetPlayerDynamicSpeed(float acceleration, float deceleration)
        {
            this.acceleration = acceleration;
            this.deceleration = deceleration;
        }

        public void SetPlayerColor(Color bodyColor, Color hatColor)
        {
            playerBodyColor = bodyColor;
            playerHatColor = hatColor;
        }

        public void SetPlayerPosition(Vector3 position)
        {
            transform.position = position;
        }

        public PlayerFSMComponent GetPlayerFsmComponent()
        {
            return playerFsmComponent;
        }

        public float GetPlayerXMoveSpeed()
        {
            return xMoveSpeed;
        }

        public float GetPlayerYMoveSpeed()
        {
            return yMoveSpeed;
        }

        public float GetPlayerAcceleration()
        {
            return acceleration;
        }

        public Rigidbody2D GetRigidbody2D()
        {
            return rb;
        }


        public void TearDown()
        {
            Destroy(gameObject);
        }
    }
}