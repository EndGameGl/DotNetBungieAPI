namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

/// <summary>
///     The character-specific data for a milestone's reward entry. See DestinyMilestoneDefinition for more information about Reward Entries.
/// </summary>
public class DestinyMilestoneRewardEntry : IDeepEquatable<DestinyMilestoneRewardEntry>
{
    /// <summary>
    ///     The identifier for the reward entry in question. It is important to look up the related DestinyMilestoneRewardEntryDefinition to get the static details about the reward, which you can do by looking up the milestone's DestinyMilestoneDefinition and examining the DestinyMilestoneDefinition.rewards[rewardCategoryHash].rewardEntries[rewardEntryHash] data.
    /// </summary>
    [JsonPropertyName("rewardEntryHash")]
    public uint RewardEntryHash { get; set; }

    /// <summary>
    ///     If TRUE, the player has earned this reward.
    /// </summary>
    [JsonPropertyName("earned")]
    public bool Earned { get; set; }

    /// <summary>
    ///     If TRUE, the player has redeemed/picked up/obtained this reward. Feel free to alias this to "gotTheShinyBauble" in your own codebase.
    /// </summary>
    [JsonPropertyName("redeemed")]
    public bool Redeemed { get; set; }

    public bool DeepEquals(DestinyMilestoneRewardEntry? other)
    {
        return other is not null &&
               RewardEntryHash == other.RewardEntryHash &&
               Earned == other.Earned &&
               Redeemed == other.Redeemed;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyMilestoneRewardEntry? other)
    {
        if (other is null) return;
        if (RewardEntryHash != other.RewardEntryHash)
        {
            RewardEntryHash = other.RewardEntryHash;
            OnPropertyChanged(nameof(RewardEntryHash));
        }
        if (Earned != other.Earned)
        {
            Earned = other.Earned;
            OnPropertyChanged(nameof(Earned));
        }
        if (Redeemed != other.Redeemed)
        {
            Redeemed = other.Redeemed;
            OnPropertyChanged(nameof(Redeemed));
        }
    }
}