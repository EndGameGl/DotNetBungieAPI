using NetBungieAPI.Models.Destiny;
using System;

namespace NetBungieAPI.Attributes
{
    public class DestinyDefinitionAttribute : Attribute
    {
        public DefinitionsEnum DefinitionEnumType { get; }
        public bool IsManuallyDisabled { get; }
        public DestinyDefinitionAttribute(DefinitionsEnum type, bool isManuallyDisabled = false)
        {
            DefinitionEnumType = type;
            IsManuallyDisabled = isManuallyDisabled;
        }
    }
}
