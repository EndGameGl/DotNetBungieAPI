using System;
using NetBungieAPI.Models.Destiny;

namespace NetBungieAPI.Providers
{
    public class ProviderUnsupportedException : Exception
    {
        public ProviderUnsupportedException(string message, DefinitionsEnum enumValue) : base(message)
        {
            EnumValue = enumValue;
        }

        public DefinitionsEnum EnumValue { get; }
    }
}