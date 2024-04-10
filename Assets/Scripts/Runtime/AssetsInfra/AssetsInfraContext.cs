using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Skiing2
{
    public class AssetsInfraContext
    {
        Dictionary<string, GameObject> entityDict;
        public AsyncOperationHandle entityHandle;

        public AssetsInfraContext()
        {
            entityDict = new Dictionary<string, GameObject>();
        }

        // Entity
        public void AddEntity(string name, GameObject prefab)
        {
            entityDict.Add(name, prefab);
        }

        bool TryGetEntity(string name, out GameObject asset)
        {
            var has = entityDict.TryGetValue(name, out asset);
            return has;
        }

        public GameObject GetPlayer()
        {
            var has = TryGetEntity("Player", out var prefab);
            if (!has)
            {
                Debug.LogError($"Entity Player not found");
            }

            return prefab;
        }

        public GameObject GetSlime()
        {
            var has = TryGetEntity("Slime_big", out var prefab);
            if (!has)
            {
                Debug.LogError($"Entity Slime not found");
            }

            return prefab;
        }

        public GameObject GetFinishLine()
        {
            var has = TryGetEntity("FinishLine", out var prefab);
            if (!has)
            {
                Debug.LogError($"Entity FinishLine not found");
            }

            return prefab;
        }
    }
}