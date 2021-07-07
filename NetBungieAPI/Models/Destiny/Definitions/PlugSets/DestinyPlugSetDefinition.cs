﻿using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;

namespace NetBungieAPI.Models.Destiny.Definitions.PlugSets
{
    /// <summary>
    ///     Sometimes, we have large sets of reusable plugs that are defined identically and thus can (and in some cases, are
    ///     so large that they *must*) be shared across the places where they are used. These are the definitions for those
    ///     reusable sets of plugs.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyPlugSetDefinition)]
    public sealed record DestinyPlugSetDefinition : IDestinyDefinition, IDeepEquatable<DestinyPlugSetDefinition>
    {
        /// <summary>
        ///     If you want to show these plugs in isolation, these are the display properties for them.
        /// </summary>
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        /// <summary>
        ///     Mostly for our debugging or reporting bugs, BNet is making "fake" plug sets in a desperate effort to reduce socket
        ///     sizes.
        ///     <para />
        ///     If this is true, the plug set was generated by BNet: if it looks wrong, that's a good indicator that it's
        ///     bungie.net that fucked this up.
        /// </summary>
        [JsonPropertyName("isFakePlugSet")]
        public bool IsFakePlugSet { get; init; }

        /// <summary>
        ///     This is a list of pre-determined plugs that can be plugged into this socket, without the character having the plug
        ///     in their inventory.
        ///     <para />
        ///     If this list is populated, you will not be allowed to plug an arbitrary item in the socket: you will only be able
        ///     to choose from one of these reusable plugs.
        /// </summary>
        [JsonPropertyName("reusablePlugItems")]
        public ReadOnlyCollection<DestinyItemSocketEntryPlugItemRandomizedDefinition> ReusablePlugItems { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyItemSocketEntryPlugItemRandomizedDefinition>();

        public bool DeepEquals(DestinyPlugSetDefinition other)
        {
            return other != null &&
                   (DisplayProperties != null
                       ? DisplayProperties.DeepEquals(other.DisplayProperties)
                       : other.DisplayProperties == null) &&
                   IsFakePlugSet == other.IsFakePlugSet &&
                   ReusablePlugItems.DeepEqualsReadOnlyCollections(other.ReusablePlugItems) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyPlugSetDefinition;
        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
            foreach (var item in ReusablePlugItems) item.PlugItem.TryMapValue();
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties?.Description}";
        }
    }
}