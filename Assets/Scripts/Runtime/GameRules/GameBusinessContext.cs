using Cinemachine;
using UnityEngine;

namespace Skiing2.GameRules
{
    public class GameBusinessContext
    {
        // Context
        public AssetsInfraContext assetsInfraContext;
        public TemplateInfraContext templateInfraContext;

        //Player
        public bool isMoving;
        public bool isTurnAround;
        public bool lastTurnAroundState;
        public float currentSpeed;
        public int direction;
        public Rigidbody2D rb;
        public GameObject background;
        public CinemachineVirtualCamera followCamera;

        // Entities
        public PlayerEntity PlayerEntity { get; set; }
        public EnemyEntity EnemyEntity { get; set; }
        public FinishLineEntity FinishLineEntity { get; set; }
        public GameEntity gameEntity;

        public Camera mainCamera;
        public int playerLayer;

        public GameBusinessContext()
        {
            direction = 1;
            isMoving = false;
            isTurnAround = false;
            lastTurnAroundState = isTurnAround;
            currentSpeed = 0;
            gameEntity = new GameEntity();
        }
        // Domain
    }
}