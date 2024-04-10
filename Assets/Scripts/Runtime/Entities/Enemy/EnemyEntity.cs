using UnityEngine;

namespace Skiing2
{
    public class EnemyEntity : MonoBehaviour
    {
        // radius
        float highScoreRadius;
        float lowScoreRadius;
        float middleScoreRadius;

        // score
        int highScore;
        int lowScore;
        int middleScore;

        // setter and getter
        public void SetRadius(float high, float middle, float low)
        {
            highScoreRadius = high;
            middleScoreRadius = middle;
            lowScoreRadius = low;
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

       

        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, highScoreRadius);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, middleScoreRadius);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, lowScoreRadius);
        }

        public void TearDown()
        {
            Destroy(gameObject);
        }
    }
}