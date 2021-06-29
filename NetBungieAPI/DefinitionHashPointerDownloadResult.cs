using NetBungieAPI.Models.Destiny;

namespace NetBungieAPI
{
    /// <summary>
    ///     Result of definition download operation
    /// </summary>
    /// <typeparam name="T">IDestinyDefinition</typeparam>
    public struct DefinitionHashPointerDownloadResult<T> where T : IDestinyDefinition
    {
        /// <summary>
        ///     Definition value
        /// </summary>
        public T Result { get; }

        /// <summary>
        ///     Whether download succeed
        /// </summary>
        public bool DidSucceed { get; }

        /// <summary>
        ///     Error, if failed to download
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        ///     .ctor
        /// </summary>
        /// <param name="result"></param>
        /// <param name="didSucceed"></param>
        /// <param name="message"></param>
        internal DefinitionHashPointerDownloadResult(T result, bool didSucceed, string message = "")
        {
            Result = result;
            DidSucceed = didSucceed;
            ErrorMessage = message;
        }
    }
}