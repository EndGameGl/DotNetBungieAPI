using DotNetBungieAPI.Models.Destiny.Definitions.Activities;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.Destinations;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Milestones;

/// <summary>
///     Any data we need to figure out whether this Quest Item is the currently active one for the conceptual Milestone.
///     Even just typing this description, I already regret it.
/// </summary>
public sealed record DestinyMilestoneQuestDefinition
    : IDeepEquatable<DestinyMilestoneQuestDefinition>
{
    /// <summary>
    ///     The item representing this Milestone quest.
    /// </summary>
    [JsonPropertyName("questItemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> QuestItem { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    /// <summary>
    ///     The individual quests may have different definitions from the overall milestone: if there's a specific active
    ///     quest, use these displayProperties instead of that of the overall DestinyMilestoneDefinition.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     If populated, this image can be shown instead of the generic milestone's image when this quest is live, or it can
    ///     be used to show a background image for the quest itself that differs from that of the Activity or the Milestone.
    /// </summary>
    [JsonPropertyName("overrideImage")]
    public BungieNetResource OverrideImage { get; init; }

    /// <summary>
    ///     The rewards you will get for completing this quest, as best as we could extract them from our data. Sometimes,
    ///     it'll be a decent amount of data. Sometimes, it's going to be sucky. Sorry.
    /// </summary>
    [JsonPropertyName("questRewards")]
    public DestinyMilestoneQuestRewardsDefinition QuestRewards { get; init; }

    /// <summary>
    ///     The full set of all possible "conceptual activities" that are related to this Milestone. Tiers or alternative modes
    ///     of play within these conceptual activities will be defined as sub-entities. Keyed by the Conceptual Activity Hash.
    ///     Use the key to look up DestinyActivityDefinition
    /// </summary>
    [JsonPropertyName("activities")]
    public ReadOnlyDictionary<
        DefinitionHashPointer<DestinyActivityDefinition>,
        DestinyMilestoneActivityDefinition
    > Activities { get; init; } =
        ReadOnlyDictionary<
            DefinitionHashPointer<DestinyActivityDefinition>,
            DestinyMilestoneActivityDefinition
        >.Empty;

    /// <summary>
    ///     Sometimes, a Milestone's quest is related to an entire Destination rather than a specific activity. In that
    ///     situation, this will be the hash of that Destination. Hotspots are currently the only Milestones that expose this
    ///     data, but that does not preclude this data from being returned for other Milestones in the future.
    /// </summary>
    [JsonPropertyName("destinationHash")]
    public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; init; } =
        DefinitionHashPointer<DestinyDestinationDefinition>.Empty;

    public bool DeepEquals(DestinyMilestoneQuestDefinition other)
    {
        return other != null
            && DisplayProperties.DeepEquals(other.DisplayProperties)
            && QuestItem.DeepEquals(other.QuestItem)
            && QuestRewards.DeepEquals(other.QuestRewards)
            && OverrideImage == other.OverrideImage
            && Destination.DeepEquals(other.Destination)
            && Activities.DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue(
                other.Activities
            );
    }
}
