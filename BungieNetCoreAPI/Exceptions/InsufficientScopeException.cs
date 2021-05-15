using System;
using NetBungieAPI.Models.Applications;

namespace NetBungieAPI.Exceptions
{
    public class InsufficientScopeException : Exception
    {
        public ApplicationScopes MissingScope { get; }
        public InsufficientScopeException(ApplicationScopes missingScope)
        : base(message: $"{missingScope} scope is required to access this API endpoint.")
        {
            MissingScope = missingScope;
        }
    }
}