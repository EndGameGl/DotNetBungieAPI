namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

/// <summary>
///     Part of our dynamic, localized Milestone content is arbitrary categories of items. These are built in our content management system, and thus aren't the same as programmatically generated rewards.
/// </summary>
public class DestinyMilestoneContentItemCategory : IDeepEquatable<DestinyMilestoneContentItemCategory>
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("itemHashes")]
    public List<uint> ItemHashes { get; set; }

    public bool DeepEquals(DestinyMilestoneContentItemCategory? other)
    {
        return other is not null &&
               Title == other.Title &&
               ItemHashes.DeepEqualsListNaive(other.ItemHashes);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyMilestoneContentItemCategory? other)
    {
        if (other is null) return;
        if (Title != other.Title)
        {
            Title = other.Title;
            OnPropertyChanged(nameof(Title));
        }
        if (!ItemHashes.DeepEqualsListNaive(other.ItemHashes))
        {
            ItemHashes = other.ItemHashes;
            OnPropertyChanged(nameof(ItemHashes));
        }
    }
}