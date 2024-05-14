using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Skiing2.GameRules.Game
{
    public class GameBusinessContext
    {
        // Context
        public AssetsInfraContext assetsInfraContext;
        public TemplateInfraContext templateInfraContext;
        public GameUIContext gameUIContext;


        //Player
        public bool isMoving;
        public bool isTurnAround;
        public bool lastTurnAroundState;
        public float currentSpeed;
        public int direction;
        public Rigidbody2D rb;
        public GameObject background;
        public CinemachineVirtualCamera followCamera;
        public Transform playerTrail;

        // Enemy
        public int startSlimeCount;
        public List<EnemyEntity> enemies;
        public Transform slimeParent;
        public float nextSpawnY;

        // Entities
        public PlayerEntity PlayerEntity { get; set; }
        public EnemyEntity EnemyEntity { get; set; }
        public FinishLineEntity FinishLineEntity { get; set; }
        public SoundEntity SoundEntity { get; set; }
        public GameEntity gameEntity;

        // 
        public Camera mainCamera;
        public int playerLayer;
        public ParticleSystem flareEffect;
        public ParticleSystem smokeEffect;
        public ParticleSystem confettiEffect;
        public Transform Bgm;

        public MonoBehaviour monoBehaviour;

        public bool isPlaySound;
        public bool isStartGame;
        public List<EnemyEntity> slimesToRemove;


        public GameBusinessContext()
        {
            isPlaySound = true;
            direction = 1;
            lastTurnAroundState = isTurnAround;
            gameEntity = new GameEntity();
            enemies = new();
            slimesToRemove = new();
        }
    }
}