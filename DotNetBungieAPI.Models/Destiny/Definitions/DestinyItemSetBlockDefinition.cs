namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     Primarily for Quests, this is the definition of properties related to the item if it is a quest and its various quest steps.
/// </summary>
public sealed class DestinyItemSetBlockDefinition
{
    /// <summary>
    ///     A collection of hashes of set items, for items such as Quest Metadata items that possess this data.
    /// </summary>
    [JsonPropertyName("itemList")]
    public Destiny.Definitions.DestinyItemSetBlockEntryDefinition[]? ItemList { get; init; }

    /// <summary>
    ///     If true, items in the set can only be added in increasing order, and adding an item will remove any previous item. For Quests, this is by necessity true. Only one quest step is present at a time, and previous steps are removed as you advance in the quest.
    /// </summary>
    [JsonPropertyName("requireOrderedSetItemAdd")]
    public bool RequireOrderedSetItemAdd { get; init; }

    /// <summary>
    ///     If true, the UI should treat this quest as "featured"
    /// </summary>
    [JsonPropertyName("setIsFeatured")]
    public bool SetIsFeatured { get; init; }

    /// <summary>
    ///     A string identifier we can use to attempt to identify the category of the Quest.
    /// </summary>
    [JsonPropertyName("setType")]
    public string SetType { get; init; }

    /// <summary>
    ///     The name of the quest line that this quest step is a part of.
    /// </summary>
    [JsonPropertyName("questLineName")]
    public string QuestLineName { get; init; }

    /// <summary>
    ///     The description of the quest line that this quest step is a part of.
    /// </summary>
    [JsonPropertyName("questLineDescription")]
    public string QuestLineDescription { get; init; }

    /// <summary>
    ///     An additional summary of this step in the quest line.
    /// </summary>
    [JsonPropertyName("questStepSummary")]
    public string QuestStepSummary { get; init; }
}
