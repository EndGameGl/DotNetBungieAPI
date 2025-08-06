namespace DotNetBungieAPI.Models.Destiny.Milestones;

/// <summary>
///     Represents localized, extended content related to Milestones. This is intentionally returned by a separate endpoint and not with Character-level Milestone data because we do not put localized data into standard Destiny responses, both for brevity of response and for caching purposes. If you really need this data, hit the Milestone Content endpoint.
/// </summary>
public sealed class DestinyMilestoneContent
{
    /// <summary>
    ///     The "About this Milestone" text from the Firehose.
    /// </summary>
    [JsonPropertyName("about")]
    public string About { get; init; }

    /// <summary>
    ///     The Current Status of the Milestone, as driven by the Firehose.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; init; }

    /// <summary>
    ///     A list of tips, provided by the Firehose.
    /// </summary>
    [JsonPropertyName("tips")]
    public string[]? Tips { get; init; }

    /// <summary>
    ///     If DPS has defined items related to this Milestone, they can categorize those items in the Firehose. That data will then be returned as item categories here.
    /// </summary>
    [JsonPropertyName("itemCategories")]
    public Destiny.Milestones.DestinyMilestoneContentItemCategory[]? ItemCategories { get; init; }
}
