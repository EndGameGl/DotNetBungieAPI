namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Primarily for Quests, this is the definition of properties related to the item if it is a quest and its various quest steps.
/// </summary>
public class DestinyItemSetBlockDefinition : IDeepEquatable<DestinyItemSetBlockDefinition>
{
    /// <summary>
    ///     A collection of hashes of set items, for items such as Quest Metadata items that possess this data.
    /// </summary>
    [JsonPropertyName("itemList")]
    public List<Destiny.Definitions.DestinyItemSetBlockEntryDefinition> ItemList { get; set; }

    /// <summary>
    ///     If true, items in the set can only be added in increasing order, and adding an item will remove any previous item. For Quests, this is by necessity true. Only one quest step is present at a time, and previous steps are removed as you advance in the quest.
    /// </summary>
    [JsonPropertyName("requireOrderedSetItemAdd")]
    public bool RequireOrderedSetItemAdd { get; set; }

    /// <summary>
    ///     If true, the UI should treat this quest as "featured"
    /// </summary>
    [JsonPropertyName("setIsFeatured")]
    public bool SetIsFeatured { get; set; }

    /// <summary>
    ///     A string identifier we can use to attempt to identify the category of the Quest.
    /// </summary>
    [JsonPropertyName("setType")]
    public string SetType { get; set; }

    /// <summary>
    ///     The name of the quest line that this quest step is a part of.
    /// </summary>
    [JsonPropertyName("questLineName")]
    public string QuestLineName { get; set; }

    /// <summary>
    ///     The description of the quest line that this quest step is a part of.
    /// </summary>
    [JsonPropertyName("questLineDescription")]
    public string QuestLineDescription { get; set; }

    /// <summary>
    ///     An additional summary of this step in the quest line.
    /// </summary>
    [JsonPropertyName("questStepSummary")]
    public string QuestStepSummary { get; set; }

    public bool DeepEquals(DestinyItemSetBlockDefinition? other)
    {
        return other is not null &&
               ItemList.DeepEqualsList(other.ItemList) &&
               RequireOrderedSetItemAdd == other.RequireOrderedSetItemAdd &&
               SetIsFeatured == other.SetIsFeatured &&
               SetType == other.SetType &&
               QuestLineName == other.QuestLineName &&
               QuestLineDescription == other.QuestLineDescription &&
               QuestStepSummary == other.QuestStepSummary;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemSetBlockDefinition? other)
    {
        if (other is null) return;
        if (!ItemList.DeepEqualsList(other.ItemList))
        {
            ItemList = other.ItemList;
            OnPropertyChanged(nameof(ItemList));
        }
        if (RequireOrderedSetItemAdd != other.RequireOrderedSetItemAdd)
        {
            RequireOrderedSetItemAdd = other.RequireOrderedSetItemAdd;
            OnPropertyChanged(nameof(RequireOrderedSetItemAdd));
        }
        if (SetIsFeatured != other.SetIsFeatured)
        {
            SetIsFeatured = other.SetIsFeatured;
            OnPropertyChanged(nameof(SetIsFeatured));
        }
        if (SetType != other.SetType)
        {
            SetType = other.SetType;
            OnPropertyChanged(nameof(SetType));
        }
        if (QuestLineName != other.QuestLineName)
        {
            QuestLineName = other.QuestLineName;
            OnPropertyChanged(nameof(QuestLineName));
        }
        if (QuestLineDescription != other.QuestLineDescription)
        {
            QuestLineDescription = other.QuestLineDescription;
            OnPropertyChanged(nameof(QuestLineDescription));
        }
        if (QuestStepSummary != other.QuestStepSummary)
        {
            QuestStepSummary = other.QuestStepSummary;
            OnPropertyChanged(nameof(QuestStepSummary));
        }
    }
}