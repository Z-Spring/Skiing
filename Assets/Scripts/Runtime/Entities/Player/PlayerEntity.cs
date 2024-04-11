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

        Rigidbody2D rb;
        Transform playerFeet;

        // Components
        PlayerFSMComponent playerFsmComponent;
        PlayerComponent playerComponent;


        public PlayerComponent PlayerComponent => playerComponent;

        public void Ctor()
        {
            playerFsmComponent = new PlayerFSMComponent();
            playerFeet = transform.GetChild(3);

            var playerBody = transform.GetChild(0);
            var playerHat = transform.GetChild(1);
            playerComponent = new PlayerComponent(playerBody, playerHat);

            rb = GetComponent<Rigidbody2D>();
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

        public Transform GetPlayerFeet()
        {
            return playerFeet;
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