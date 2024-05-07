using UnityEngine;

namespace Skiing2.GameUI
{
    public static class UIFactory
    {
        static GameObject GetUIPrefab(GameUIContext ctx, string name)
        {
            if (ctx.prefabDict.TryGetValue(name, out var prefab))
            {
                return prefab;
            }

            Debug.LogError($"UIFactory.GetUIPrefab: {name} not found");
            return null;
        }

        public static T OpenPanel<T>(GameUIContext ctx) where T : MonoBehaviour
        {
            string name = typeof(T).Name;
            var prefab = GetUIPrefab(ctx, name);
            var panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<T>();
            ctx.AddIndividualPanelToCache(name, panel);
            return panel;
        }

        public static void ClosePanel<T>(GameUIContext ctx) where T : MonoBehaviour
        {
            string name = typeof(T).Name;
            if (ctx.TryGetIndividualPanel(name, out var panel))
            {
                ctx.RemoveIndividualPanelFromCache(name);
                GameObject.Destroy(panel.gameObject);
            }
            else
            {
                Debug.LogWarning($"UIFactory.CloseUniquePanel: {name} not found");
            }
        }
    }
}