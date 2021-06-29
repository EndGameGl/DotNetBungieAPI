using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Components;

namespace NetBungieAPI.Models.Destiny.Responses
{
    public sealed record DestinyItemChangeResponse
    {
        [JsonPropertyName("item")] public DestinyItemResponse Item { get; init; }

        /// <summary>
        ///     Items that appeared in the inventory possibly as a result of an action.
        /// </summary>
        [JsonPropertyName("addedInventoryItems")]
        public ReadOnlyCollection<DestinyItemComponent> AddedInventoryItems { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyItemComponent>();

        /// <summary>
        ///     Items that disappeared from the inventory possibly as a result of an action.
        /// </summary>
        [JsonPropertyName("removedInventoryItems")]
        public ReadOnlyCollection<DestinyItemComponent> RemovedInventoryItems { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyItemComponent>();
    }
}