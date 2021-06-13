using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// If defined, the item has at least one socket.
    /// </summary>
    public sealed record DestinyItemSocketBlockDefinition : IDeepEquatable<DestinyItemSocketBlockDefinition>
    {
        /// <summary>
        /// This was supposed to be a string that would give per-item details about sockets. In practice, it turns out that all this ever has is the localized word "details".
        /// </summary>
        [JsonPropertyName("detail")]
        public string Detail { get; init; }

        /// <summary>
        /// Each intrinsic (or immutable/permanent) socket on an item is defined here, along with the plug that is permanently affixed to the socket.
        /// </summary>
        [JsonPropertyName("intrinsicSockets")]
        public ReadOnlyCollection<DestinyItemIntrinsicSocketEntryDefinition> IntrinsicSockets { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyItemIntrinsicSocketEntryDefinition>();

        /// <summary>
        /// A convenience property, that refers to the sockets in the "sockets" property, pre-grouped by category and ordered in the manner that they should be grouped in the UI.
        /// </summary>
        [JsonPropertyName("socketCategories")]
        public ReadOnlyCollection<DestinyItemSocketCategoryDefinition> SocketCategories { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyItemSocketCategoryDefinition>();

        /// <summary>
        /// Each non-intrinsic (or mutable) socket on an item is defined here.
        /// </summary>
        [JsonPropertyName("socketEntries")]
        public ReadOnlyCollection<DestinyItemSocketEntryDefinition> SocketEntries { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyItemSocketEntryDefinition>();

        public bool DeepEquals(DestinyItemSocketBlockDefinition other)
        {
            return other != null &&
                   Detail == other.Detail &&
                   IntrinsicSockets.DeepEqualsReadOnlyCollections(other.IntrinsicSockets) &&
                   SocketCategories.DeepEqualsReadOnlyCollections(other.SocketCategories) &&
                   SocketEntries.DeepEqualsReadOnlyCollections(other.SocketEntries);
        }

        public override string ToString()
        {
            return $"{SocketEntries.Count} sockets available.";
        }
    }
}