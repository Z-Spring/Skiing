using System.Collections.Generic;
using UnityEngine;

namespace Skiing2
{
    public static class SlimePool
    {
        static  Queue<GameObject> slimePool ;
        public static GameObject slimePrefab;
        public static Transform parent;

        public static void InitPool(int initSlimeNum)
        {
            slimePool = new();
            SpawnSlime(initSlimeNum);
        }

        static void SpawnSlime(int num)
        {
            for (int i = 0; i < num; i++)
            {
                GameObject go = GameObject.Instantiate(slimePrefab,parent);
                go.SetActive(false);
                slimePool.Enqueue(go);
            }
        }

        public static void ReturnSlime(GameObject slime)
        {
            slimePool.Enqueue(slime);
            slime.SetActive(false);
        }

        public static GameObject GetSlimeFromPool()
        {
            if (slimePool.Count == 0)
            {
                SpawnSlime(1);
            }

            GameObject go = slimePool.Dequeue();
            go.SetActive(true);
            return go;
        }
        
        public static void TearDown()
        {
            slimePool.Clear();
        } 
    }
}