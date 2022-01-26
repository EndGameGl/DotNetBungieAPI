namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

/// <summary>
///     The definition of a category of rewards, that contains many individual rewards.
/// </summary>
public class DestinyMilestoneRewardCategoryDefinition : IDeepEquatable<DestinyMilestoneRewardCategoryDefinition>
{
    /// <summary>
    ///     Identifies the reward category. Only guaranteed unique within this specific component!
    /// </summary>
    [JsonPropertyName("categoryHash")]
    public uint CategoryHash { get; set; }

    /// <summary>
    ///     The string identifier for the category, if you want to use it for some end. Guaranteed unique within the specific component.
    /// </summary>
    [JsonPropertyName("categoryIdentifier")]
    public string CategoryIdentifier { get; set; }

    /// <summary>
    ///     Hopefully this is obvious by now.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     If this milestone can provide rewards, this will define the sets of rewards that can be earned, the conditions under which they can be acquired, internal data that we'll use at runtime to determine whether you've already earned or redeemed this set of rewards, and the category that this reward should be placed under.
    /// </summary>
    [JsonPropertyName("rewardEntries")]
    public Dictionary<uint, Destiny.Definitions.Milestones.DestinyMilestoneRewardEntryDefinition> RewardEntries { get; set; }

    /// <summary>
    ///     If you want to use BNet's recommended order for rendering categories programmatically, use this value and compare it to other categories to determine the order in which they should be rendered. I don't feel great about putting this here, I won't lie.
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; set; }

    public bool DeepEquals(DestinyMilestoneRewardCategoryDefinition? other)
    {
        return other is not null &&
               CategoryHash == other.CategoryHash &&
               CategoryIdentifier == other.CategoryIdentifier &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               RewardEntries.DeepEqualsDictionary(other.RewardEntries) &&
               Order == other.Order;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyMilestoneRewardCategoryDefinition? other)
    {
        if (other is null) return;
        if (CategoryHash != other.CategoryHash)
        {
            CategoryHash = other.CategoryHash;
            OnPropertyChanged(nameof(CategoryHash));
        }
        if (CategoryIdentifier != other.CategoryIdentifier)
        {
            CategoryIdentifier = other.CategoryIdentifier;
            OnPropertyChanged(nameof(CategoryIdentifier));
        }
        if (!DisplayProperties.DeepEquals(other.DisplayProperties))
        {
            DisplayProperties.Update(other.DisplayProperties);
            OnPropertyChanged(nameof(DisplayProperties));
        }
        if (!RewardEntries.DeepEqualsDictionary(other.RewardEntries))
        {
            RewardEntries = other.RewardEntries;
            OnPropertyChanged(nameof(RewardEntries));
        }
        if (Order != other.Order)
        {
            Order = other.Order;
            OnPropertyChanged(nameof(Order));
        }
    }
}