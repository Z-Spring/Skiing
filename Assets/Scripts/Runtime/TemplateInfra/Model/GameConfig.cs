using UnityEngine;

namespace Skiing2
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "SO/GameConfig", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [Title("SlimePool")] 
        public int initSlimeNum;

        [Title("Slime")] 
        public float highScoreRadius;
        public float lowScoreRadius;
        public float middleScoreRadius;
        public float colliderRadius;
        public int highScore;
        public int lowScore;
        public int middleScore;

        [Title("Player")] 
        public float xSpeed;
        public float ySpeed;
        public float acceleration;
        public float deceleration;

        [Title("FinishLine")] 
        public float finishLineY;
        
        [Title("Audio Clip")]
        public AudioClip bgm;
        public AudioClip dead;
        public AudioClip fever;
        public AudioClip levelUp;
        public AudioClip ski;
        public AudioClip perfect;
    }
}