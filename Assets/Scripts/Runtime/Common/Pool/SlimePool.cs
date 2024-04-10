using System.Collections.Generic;
using UnityEngine;

namespace Skiing2.Runtime.Common.Pool
{
    public class SlimePool : MonoBehaviour
    {
        int initSlimeNum;
        GameObject[] slimePrefabs;

        readonly Queue<GameObject> enemyPool = new();


        public void InitPool()
        {
            SpawnSlime(initSlimeNum);
        }

        void SpawnSlime(int num)
        {
            for (int i = 0; i < num; i++)
            {
                var randomEnemy = slimePrefabs[Random.Range(0, slimePrefabs.Length)];
                GameObject go = Instantiate(randomEnemy, transform);
                go.SetActive(false);
                enemyPool.Enqueue(go);
            }
        }

        public void ReturnSlime(GameObject slime)
        {
            enemyPool.Enqueue(slime);
            slime.SetActive(false);
        }

        public GameObject GetSlimeFromPool()
        {
            if (enemyPool.Count == 0)
            {
                SpawnSlime(1);
            }

            GameObject go = enemyPool.Dequeue();
            go.SetActive(true);
            return go;
        }
    }
}