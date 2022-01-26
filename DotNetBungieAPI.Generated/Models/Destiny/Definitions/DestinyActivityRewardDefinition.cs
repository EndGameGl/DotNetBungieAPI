namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Activities can refer to one or more sets of tooltip-friendly reward data. These are the definitions for those tooltip friendly rewards.
/// </summary>
public class DestinyActivityRewardDefinition : IDeepEquatable<DestinyActivityRewardDefinition>
{
    /// <summary>
    ///     The header for the reward set, if any.
    /// </summary>
    [JsonPropertyName("rewardText")]
    public string RewardText { get; set; }

    /// <summary>
    ///     The "Items provided" in the reward. This is almost always a pointer to a DestinyInventoryItemDefintion for an item that you can't actually earn in-game, but that has name/description/icon information for the vague concept of the rewards you will receive. This is because the actual reward generation is non-deterministic and extremely complicated, so the best the game can do is tell you what you'll get in vague terms. And so too shall we.
    /// <para />
    ///     Interesting trivia: you actually *do* earn these items when you complete the activity. They go into a single-slot bucket on your profile, which is how you see the pop-ups of these rewards when you complete an activity that match these "dummy" items. You can even see them if you look at the last one you earned in your profile-level inventory through the BNet API! Who said reading documentation is a waste of time?
    /// </summary>
    [JsonPropertyName("rewardItems")]
    public List<Destiny.DestinyItemQuantity> RewardItems { get; set; }

    public bool DeepEquals(DestinyActivityRewardDefinition? other)
    {
        return other is not null &&
               RewardText == other.RewardText &&
               RewardItems.DeepEqualsList(other.RewardItems);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyActivityRewardDefinition? other)
    {
        if (other is null) return;
        if (RewardText != other.RewardText)
        {
            RewardText = other.RewardText;
            OnPropertyChanged(nameof(RewardText));
        }
        if (!RewardItems.DeepEqualsList(other.RewardItems))
        {
            RewardItems = other.RewardItems;
            OnPropertyChanged(nameof(RewardItems));
        }
    }
}