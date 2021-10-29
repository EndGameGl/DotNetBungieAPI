using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.Destiny.Components;

namespace DotNetBungieAPI.Models.Destiny.Responses
{
    public sealed record DestinyItemChangeResponse
    {
        [JsonPropertyName("item")] public DestinyItemResponse Item { get; init; }

        /// <summary>
        ///     Items that appeared in the inventory possibly as a result of an action.
        /// </summary>
        [JsonPropertyName("addedInventoryItems")]
        public ReadOnlyCollection<DestinyItemComponent> AddedInventoryItems { get; init; } =
            ReadOnlyCollections<DestinyItemComponent>.Empty;

        /// <summary>
        ///     Items that disappeared from the inventory possibly as a result of an action.
        /// </summary>
        [JsonPropertyName("removedInventoryItems")]
        public ReadOnlyCollection<DestinyItemComponent> RemovedInventoryItems { get; init; } =
            ReadOnlyCollections<DestinyItemComponent>.Empty;
    }
}