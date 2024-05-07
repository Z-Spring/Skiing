using System.Threading.Tasks;
using Skiing2.GameUI;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Skiing2
{
    public class UI
    {
        public static async Task LoadAssets(GameUIContext ctx)
        {
            var list = await Addressables.LoadAssetsAsync<GameObject>("UI", null).Task;
            foreach (var prefab in list)
            {
                ctx.AddPrefab(prefab.name, prefab);
            }
        }
        
        public static void SettingPanelOpen(GameUIContext ctx)
        {
            SettingPanelDomain.Open(ctx);
        }
        
        public static void SettingPanelClose(GameUIContext ctx)
        {
            SettingPanelDomain.Close(ctx);
        }
    }
}