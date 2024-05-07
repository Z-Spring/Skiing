using System.Collections.Generic;
using Runtime.GameUI;
using UnityEngine;

namespace Skiing2
{
    public class GameUIContext
    {
        public Dictionary<string, GameObject> prefabDict;
        public Dictionary<string, MonoBehaviour> IndividualPanelCache;

        public Canvas canvas;
        public UIEventCenter eventCenter;

        public GameUIContext()
        {
            prefabDict = new Dictionary<string, GameObject>();
            IndividualPanelCache = new Dictionary<string, MonoBehaviour>();
            eventCenter = new UIEventCenter();
        }

        public void AddPrefab(string name, GameObject prefab)
        {
            prefabDict.Add(name, prefab);
        }

        public void AddIndividualPanelToCache(string name, MonoBehaviour panel)
        {
            IndividualPanelCache.Add(name, panel);
        }

        public void RemoveIndividualPanelFromCache(string name)
        {
            IndividualPanelCache.Remove(name);
        }

        public bool TryGetIndividualPanel(string name, out MonoBehaviour panel)
        {
            return IndividualPanelCache.TryGetValue(name, out panel);
        }

        public T GetIndividualPanel<T>() where T : MonoBehaviour
        {
            string name = typeof(T).Name;
            bool has = IndividualPanelCache.TryGetValue(name, out var prefab);
            if (!has)
            {
                Debug.LogError($"GameUIContext.GetIndividualPanel<{name}>: UI Prefab not found");
                return null;
            }

            var panel = prefab as T;
            return panel;
        }
    }
}