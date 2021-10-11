﻿using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    public sealed record DestinyParentItemOverride : IDeepEquatable<DestinyParentItemOverride>
    {
        [JsonPropertyName("additionalEquipRequirementsDisplayStrings")]
        public ReadOnlyCollection<string> AdditionalEquipRequirementsDisplayStrings { get; init; } =
            Defaults.EmptyReadOnlyCollection<string>();

        [JsonPropertyName("pipIcon")] public DestinyResource PipIcon { get; init; }

        public bool DeepEquals(DestinyParentItemOverride other)
        {
            return other != null &&
                   AdditionalEquipRequirementsDisplayStrings.DeepEqualsReadOnlySimpleCollection(
                       other.AdditionalEquipRequirementsDisplayStrings) &&
                   PipIcon == other.PipIcon;
        }
    }
}