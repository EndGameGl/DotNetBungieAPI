namespace DotNetBungieAPI.Models.Destiny.Milestones;

/// <summary>
///     Part of our dynamic, localized Milestone content is arbitrary categories of items. These are built in our content management system, and thus aren't the same as programmatically generated rewards.
/// </summary>
public sealed class DestinyMilestoneContentItemCategory
{
    [JsonPropertyName("title")]
    public string Title { get; init; }

    [JsonPropertyName("itemHashes")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition>[]? ItemHashes { get; init; }
}
