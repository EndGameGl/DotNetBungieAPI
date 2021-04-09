﻿using NetBungieAPI.Models.Destiny.Definitions.Records;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.PresentationNodes
{
    public sealed record DestinyPresentationNodeRecordChildEntry : IDeepEquatable<DestinyPresentationNodeRecordChildEntry>
    {
        [JsonPropertyName("recordHash")]
        public DefinitionHashPointer<DestinyRecordDefinition> Record { get; init; } = DefinitionHashPointer<DestinyRecordDefinition>.Empty;

        public bool DeepEquals(DestinyPresentationNodeRecordChildEntry other)
        {
            return other != null && Record.DeepEquals(other.Record);
        }
    }
}