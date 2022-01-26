namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

/// <summary>
///     The definition of a specific reward, which may be contained in a category of rewards and that has optional information about how it is obtained.
/// </summary>
public class DestinyMilestoneRewardEntryDefinition : IDeepEquatable<DestinyMilestoneRewardEntryDefinition>
{
    /// <summary>
    ///     The identifier for this reward entry. Runtime data will refer to reward entries by this hash. Only guaranteed unique within the specific Milestone.
    /// </summary>
    [JsonPropertyName("rewardEntryHash")]
    public uint RewardEntryHash { get; set; }

    /// <summary>
    ///     The string identifier, if you care about it. Only guaranteed unique within the specific Milestone.
    /// </summary>
    [JsonPropertyName("rewardEntryIdentifier")]
    public string RewardEntryIdentifier { get; set; }

    /// <summary>
    ///     The items you will get as rewards, and how much of it you'll get.
    /// </summary>
    [JsonPropertyName("items")]
    public List<Destiny.DestinyItemQuantity> Items { get; set; }

    /// <summary>
    ///     If this reward is redeemed at a Vendor, this is the hash of the Vendor to go to in order to redeem the reward. Use this hash to look up the DestinyVendorDefinition.
    /// </summary>
    [JsonPropertyName("vendorHash")]
    public uint? VendorHash { get; set; }

    /// <summary>
    ///     For us to bother returning this info, we should be able to return some kind of information about why these rewards are grouped together. This is ideally that information. Look at how confident I am that this will always remain true.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     If you want to follow BNet's ordering of these rewards, use this number within a given category to order the rewards. Yeah, I know. I feel dirty too.
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; set; }

    public bool DeepEquals(DestinyMilestoneRewardEntryDefinition? other)
    {
        return other is not null &&
               RewardEntryHash == other.RewardEntryHash &&
               RewardEntryIdentifier == other.RewardEntryIdentifier &&
               Items.DeepEqualsList(other.Items) &&
               VendorHash == other.VendorHash &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               Order == other.Order;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyMilestoneRewardEntryDefinition? other)
    {
        if (other is null) return;
        if (RewardEntryHash != other.RewardEntryHash)
        {
            RewardEntryHash = other.RewardEntryHash;
            OnPropertyChanged(nameof(RewardEntryHash));
        }
        if (RewardEntryIdentifier != other.RewardEntryIdentifier)
        {
            RewardEntryIdentifier = other.RewardEntryIdentifier;
            OnPropertyChanged(nameof(RewardEntryIdentifier));
        }
        if (!Items.DeepEqualsList(other.Items))
        {
            Items = other.Items;
            OnPropertyChanged(nameof(Items));
        }
        if (VendorHash != other.VendorHash)
        {
            VendorHash = other.VendorHash;
            OnPropertyChanged(nameof(VendorHash));
        }
        if (!DisplayProperties.DeepEquals(other.DisplayProperties))
        {
            DisplayProperties.Update(other.DisplayProperties);
            OnPropertyChanged(nameof(DisplayProperties));
        }
        if (Order != other.Order)
        {
            Order = other.Order;
            OnPropertyChanged(nameof(Order));
        }
    }
}