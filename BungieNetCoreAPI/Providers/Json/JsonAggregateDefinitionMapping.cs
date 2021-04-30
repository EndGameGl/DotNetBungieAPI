using System.Collections.Generic;
using NetBungieAPI.Models.Destiny;

namespace NetBungieAPI.Providers.Json
{
    public class JsonAggregateDefinitionMapping
    {
        public Dictionary<DefinitionsEnum, JsonAggregateDefinitionTypeMapping> Mappings { get; } = new();
    }
}