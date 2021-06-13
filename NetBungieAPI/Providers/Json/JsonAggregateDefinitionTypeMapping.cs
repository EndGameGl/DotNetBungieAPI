using System;
using System.Collections.Generic;

namespace NetBungieAPI.Providers.Json
{
    public class JsonAggregateDefinitionTypeMapping
    {
        public Dictionary<uint, JsonAggregateDefinitionTypeUnitMapping> DefinitionsData { get; } = new();
    }
}