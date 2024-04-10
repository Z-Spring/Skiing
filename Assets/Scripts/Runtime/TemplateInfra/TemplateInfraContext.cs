using UnityEngine.ResourceManagement.AsyncOperations;

namespace Skiing2
{
    public class TemplateInfraContext
    {
        public AsyncOperationHandle configHandle;
        public GameConfig GameConfig { get; set; }
    }
}