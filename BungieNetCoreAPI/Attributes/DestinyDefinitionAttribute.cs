using NetBungieApi.Destiny;
using System;

namespace NetBungieApi.Attributes
{
    public class DestinyDefinitionAttribute : Attribute
    {
        public DefinitionsEnum DefinitionEnumType { get; }
        public DefinitionSources Sources { get; }
        public DefinitionKeyType KeyType { get; }
        public bool IsManuallyDisabled { get; }
        public DestinyDefinitionAttribute(DefinitionsEnum type, DefinitionSources sources, DefinitionKeyType keyType, bool isManuallyDisabled = false)
        {
            DefinitionEnumType = type;
            Sources = sources;
            KeyType = keyType;
            IsManuallyDisabled = isManuallyDisabled;
        }
    }
}
