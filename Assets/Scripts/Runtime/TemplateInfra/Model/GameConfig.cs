using Cinemachine;
using Common.Attributes;
using UnityEngine;

namespace Skiing2
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "SO/GameConfig", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [Title("Background")] 
        public GameObject backgroundPrefab;

        [Title("SlimePool")] 
        public int initSlimeNum;
        public GameObject[] slimePrefabs;

        [Title("Slime")] 
        public float highScoreRadius;
        public float lowScoreRadius;
        public float middleScoreRadius;
        public int highScore;
        public int lowScore;
        public int middleScore;

        [Title("Player")] 
        public float xSpeed;
        public float ySpeed;
        public float acceleration;
        public float deceleration;

        [Title("FinishLine")] 
        public GameObject finishLinePrefab;
        public float finishLineY;
        
    }
}