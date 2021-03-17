using NetBungieAPI.Destiny.Definitions;

namespace NetBungieAPI
{
    public class DefinitionHashPointerDownloadResult<T> where T : IDestinyDefinition
    {
        public T Result { get; }
        public bool DidSucceed { get; }
        public string ErrorMessage { get; }
        public DefinitionHashPointerDownloadResult(T result, bool didSucceed, string message = "")
        {
            Result = result;
            DidSucceed = didSucceed;
            ErrorMessage = message;
        }
    }
}
