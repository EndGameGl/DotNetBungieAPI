namespace DotNetBungieAPI.Models.Destiny.Milestones;

/// <summary>
///     Information about milestones, presented in a character state-agnostic manner. Combine this data with DestinyMilestoneDefinition to get a full picture of the milestone, which is basically a checklist of things to do in the game. Think of this as GetPublicAdvisors 3.0, for those who used the Destiny 1 API.
/// </summary>
public sealed class DestinyPublicMilestone
{
    /// <summary>
    ///     The hash identifier for the milestone. Use it to look up the DestinyMilestoneDefinition for static data about the Milestone.
    /// </summary>
    [JsonPropertyName("milestoneHash")]
    public DefinitionHashPointer<Destiny.Definitions.Milestones.DestinyMilestoneDefinition> MilestoneHash { get; init; }

    /// <summary>
    ///     A milestone not need have even a single quest, but if there are active quests they will be returned here.
    /// </summary>
    [JsonPropertyName("availableQuests")]
    public Destiny.Milestones.DestinyPublicMilestoneQuest[]? AvailableQuests { get; init; }

    [JsonPropertyName("activities")]
    public Destiny.Milestones.DestinyPublicMilestoneChallengeActivity[]? Activities { get; init; }

    /// <summary>
    ///     Sometimes milestones - or activities active in milestones - will have relevant vendors. These are the vendors that are currently relevant.
    /// <para />
    ///     Deprecated, already, for the sake of the new "vendors" property that has more data. What was I thinking.
    /// </summary>
    [JsonPropertyName("vendorHashes")]
    public uint[]? VendorHashes { get; init; }

    /// <summary>
    ///     This is why we can't have nice things. This is the ordered list of vendors to be shown that relate to this milestone, potentially along with other interesting data.
    /// </summary>
    [JsonPropertyName("vendors")]
    public Destiny.Milestones.DestinyPublicMilestoneVendor[]? Vendors { get; init; }

    /// <summary>
    ///     If known, this is the date when the Milestone started/became active.
    /// </summary>
    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; init; }

    /// <summary>
    ///     If known, this is the date when the Milestone will expire/recycle/end.
    /// </summary>
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    /// <summary>
    ///     Used for ordering milestones in a display to match how we order them in BNet. May pull from static data, or possibly in the future from dynamic information.
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; init; }
}
