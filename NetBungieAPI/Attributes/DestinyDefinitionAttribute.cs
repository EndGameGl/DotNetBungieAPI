using System;
using NetBungieAPI.Models.Destiny;

namespace NetBungieAPI.Attributes
{
    public class DestinyDefinitionAttribute : Attribute
    {
        public DestinyDefinitionAttribute(DefinitionsEnum type, bool isManuallyDisabled = false)
        {
            DefinitionEnumType = type;
            IsManuallyDisabled = isManuallyDisabled;
        }

        public DefinitionsEnum DefinitionEnumType { get; }
        public bool IsManuallyDisabled { get; }
    }
}