using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Skiing2
{
    public static class TemplateInfra
    {
        public static async Task LoadAssets(TemplateInfraContext ctx)
        {
            var handle = Addressables.LoadAssetAsync<GameConfig>("Config");
            var config = await handle.Task;
            ctx.configHandle = handle;
            ctx.GameConfig = config;
        }

        public static void ReleaseAssets(TemplateInfraContext ctx)
        {
            Addressables.Release(ctx.configHandle);
        }
    }
}