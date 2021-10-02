using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Destiny.Milestones
{
    /// <summary>
    ///     Part of our dynamic, localized Milestone content is arbitrary categories of items. These are built in our content
    ///     management system, and thus aren't the same as programmatically generated rewards.
    /// </summary>
    public sealed record DestinyMilestoneContentItemCategory
    {
        [JsonPropertyName("title")] public string Title { get; init; }

        [JsonPropertyName("itemHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>> Items { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>>();
    }
}