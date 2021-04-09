﻿using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Records
{
    public sealed record DestinyRecordExpirationBlock : IDeepEquatable<DestinyRecordExpirationBlock>
    {
        [JsonPropertyName("description")]
        public string Description { get; init; }
        [JsonPropertyName("hasExpiration")]
        public bool HasExpiration { get; init; }
        [JsonPropertyName("icon")]
        public string Icon { get; init; }

        public bool DeepEquals(DestinyRecordExpirationBlock other)
        {
            return other != null &&
                   Description == other.Description &&
                   HasExpiration == other.HasExpiration &&
                   Icon == other.Icon;
        }
    }
}