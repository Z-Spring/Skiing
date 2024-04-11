using UnityEngine;

namespace Skiing2
{
    public class EnemyEntity : MonoBehaviour
    {
        // radius
        float highScoreRadius;
        float lowScoreRadius;
        float middleScoreRadius;
        float colliderRadius;

        // score
        int highScore;
        int lowScore;
        int middleScore;

        // setter and getter
        public void SetRadius(float high, float middle, float low, float collider)
        {
            highScoreRadius = high;
            middleScoreRadius = middle;
            lowScoreRadius = low;
            colliderRadius = collider;
        }

        public void SetScore(int high, int middle, int low)
        {
            highScore = high;
            middleScore = middle;
            lowScore = low;
        }

        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }

        public int HighScore => highScore;
        public int LowScore => lowScore;
        public int MiddleScore => middleScore;

        public float HighScoreRadius => highScoreRadius;
        public float LowScoreRadius => lowScoreRadius;
        public float MiddleScoreRadius => middleScoreRadius;
        public float ColliderRadius => colliderRadius;


        void OnDrawGizmos()
        {
            var pos = transform.position;
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(pos, highScoreRadius);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(pos, middleScoreRadius);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(pos, lowScoreRadius);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(pos, colliderRadius);
        }

        public void TearDown()
        {
            SlimePool.ReturnSlime(gameObject);
        }
    }
}