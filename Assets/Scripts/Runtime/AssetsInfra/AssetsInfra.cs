using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Skiing2
{
    public static class AssetsInfra
    {
        public static async Task LoadAssets(AssetsInfraContext ctx)
        {
            var handle = Addressables.LoadAssetsAsync<GameObject>("Entity", null);
            var list = await handle.Task;
            foreach (var asset in list)
            {
                ctx.AddEntity(asset.name, asset);
            }

            ctx.entityHandle = handle;
        }

        public static void ReleaseAssets(AssetsInfraContext ctx)
        {
            if (ctx.entityHandle.IsValid())
            {
                Addressables.Release(ctx.entityHandle);
            }
        }
    }
}