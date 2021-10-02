using System;
using DotNetBungieAPI.Models.Applications;

namespace DotNetBungieAPI.Exceptions
{
    /// <summary>
    ///     Exception for handling insufficient api scope on calls
    /// </summary>
    public class InsufficientScopeException : Exception
    {
        /// <summary>
        ///     .ctor
        /// </summary>
        /// <param name="missingScope"></param>
        public InsufficientScopeException(ApplicationScopes missingScope)
            : base($"{missingScope} scope is required to access this API endpoint.")
        {
            MissingScope = missingScope;
        }

        /// <summary>
        ///     The scope that is missing on call
        /// </summary>
        public ApplicationScopes MissingScope { get; }
    }
}