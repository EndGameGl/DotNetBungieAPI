namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Profiles;

/// <summary>
///     This represents a single "thing" being tracked by the player.
/// <para />
///     This can point to many types of entities, but only a subset of them will actually have a valid hash identifier for whatever it is being pointed to.
/// <para />
///     It's up to you to interpret what it means when various combinations of these entries have values being tracked.
/// </summary>
public class DestinyProfileTransitoryTrackingEntry
{
    /// <summary>
    ///     OPTIONAL - If this is tracking a DestinyLocationDefinition, this is the identifier for that location.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyLocationDefinition>("Destiny.Definitions.DestinyLocationDefinition")]
    [JsonPropertyName("locationHash")]
    public uint? LocationHash { get; set; }

    /// <summary>
    ///     OPTIONAL - If this is tracking the status of a DestinyInventoryItemDefinition, this is the identifier for that item.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("itemHash")]
    public uint? ItemHash { get; set; }

    /// <summary>
    ///     OPTIONAL - If this is tracking the status of a DestinyObjectiveDefinition, this is the identifier for that objective.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyObjectiveDefinition>("Destiny.Definitions.DestinyObjectiveDefinition")]
    [JsonPropertyName("objectiveHash")]
    public uint? ObjectiveHash { get; set; }

    /// <summary>
    ///     OPTIONAL - If this is tracking the status of a DestinyActivityDefinition, this is the identifier for that activity.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyActivityDefinition>("Destiny.Definitions.DestinyActivityDefinition")]
    [JsonPropertyName("activityHash")]
    public uint? ActivityHash { get; set; }

    /// <summary>
    ///     OPTIONAL - If this is tracking the status of a quest, this is the identifier for the DestinyInventoryItemDefinition that containst that questline data.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("questlineItemHash")]
    public uint? QuestlineItemHash { get; set; }

    /// <summary>
    ///     OPTIONAL - I've got to level with you, I don't really know what this is. Is it when you started tracking it? Is it only populated for tracked items that have time limits?
    /// <para />
    ///     I don't know, but we can get at it - when I get time to actually test what it is, I'll update this. In the meantime, bask in the mysterious data.
    /// </summary>
    [JsonPropertyName("trackedDate")]
    public DateTime? TrackedDate { get; set; }
}
