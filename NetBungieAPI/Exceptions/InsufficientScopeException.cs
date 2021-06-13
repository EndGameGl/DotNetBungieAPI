using System;
using NetBungieAPI.Models.Applications;

namespace NetBungieAPI.Exceptions
{
    /// <summary>
    /// Exception for handling insufficient api scope on calls
    /// </summary>
    public class InsufficientScopeException : Exception
    {
        /// <summary>
        /// The scope that is missing on call
        /// </summary>
        public ApplicationScopes MissingScope { get; }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="missingScope"></param>
        public InsufficientScopeException(ApplicationScopes missingScope)
            : base(message: $"{missingScope} scope is required to access this API endpoint.")
        {
            MissingScope = missingScope;
        }
    }
}