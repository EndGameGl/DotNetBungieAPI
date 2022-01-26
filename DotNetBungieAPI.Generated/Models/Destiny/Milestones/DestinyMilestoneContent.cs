namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

/// <summary>
///     Represents localized, extended content related to Milestones. This is intentionally returned by a separate endpoint and not with Character-level Milestone data because we do not put localized data into standard Destiny responses, both for brevity of response and for caching purposes. If you really need this data, hit the Milestone Content endpoint.
/// </summary>
public class DestinyMilestoneContent : IDeepEquatable<DestinyMilestoneContent>
{
    /// <summary>
    ///     The "About this Milestone" text from the Firehose.
    /// </summary>
    [JsonPropertyName("about")]
    public string About { get; set; }

    /// <summary>
    ///     The Current Status of the Milestone, as driven by the Firehose.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary>
    ///     A list of tips, provided by the Firehose.
    /// </summary>
    [JsonPropertyName("tips")]
    public List<string> Tips { get; set; }

    /// <summary>
    ///     If DPS has defined items related to this Milestone, they can categorize those items in the Firehose. That data will then be returned as item categories here.
    /// </summary>
    [JsonPropertyName("itemCategories")]
    public List<Destiny.Milestones.DestinyMilestoneContentItemCategory> ItemCategories { get; set; }

    public bool DeepEquals(DestinyMilestoneContent? other)
    {
        return other is not null &&
               About == other.About &&
               Status == other.Status &&
               Tips.DeepEqualsListNaive(other.Tips) &&
               ItemCategories.DeepEqualsList(other.ItemCategories);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyMilestoneContent? other)
    {
        if (other is null) return;
        if (About != other.About)
        {
            About = other.About;
            OnPropertyChanged(nameof(About));
        }
        if (Status != other.Status)
        {
            Status = other.Status;
            OnPropertyChanged(nameof(Status));
        }
        if (!Tips.DeepEqualsListNaive(other.Tips))
        {
            Tips = other.Tips;
            OnPropertyChanged(nameof(Tips));
        }
        if (!ItemCategories.DeepEqualsList(other.ItemCategories))
        {
            ItemCategories = other.ItemCategories;
            OnPropertyChanged(nameof(ItemCategories));
        }
    }
}