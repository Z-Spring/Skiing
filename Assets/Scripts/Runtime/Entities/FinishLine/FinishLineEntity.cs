using UnityEngine;

namespace Skiing2
{
    public class FinishLineEntity : MonoBehaviour
    {
        float finishLineY;

        public void SetPosition(Vector2 pos)
        {
            transform.position = pos;
        }

        public void SetFinishLineY(float y)
        {
            finishLineY = y;
        }

        public float GetFinishLineY()
        {
            return finishLineY;
        }

        public void TearDown()
        {
            Destroy(gameObject);
        }
    }
}