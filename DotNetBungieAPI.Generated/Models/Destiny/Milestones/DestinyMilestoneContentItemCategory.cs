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
}