using NetBungieAPI.Models.Destiny;
using System;

namespace NetBungieAPI.Attributes
{
    public class DestinyDefinitionAttribute : Attribute
    {
        public DefinitionsEnum DefinitionEnumType { get; init; }
        public DefinitionSources Sources { get; init; }
        public DefinitionKeyType KeyType { get; init; }
        public bool IsManuallyDisabled { get; init; }
        public DestinyDefinitionAttribute(DefinitionsEnum type, DefinitionSources sources, DefinitionKeyType keyType, bool isManuallyDisabled = false)
        {
            DefinitionEnumType = type;
            Sources = sources;
            KeyType = keyType;
            IsManuallyDisabled = isManuallyDisabled;
        }
    }
}
