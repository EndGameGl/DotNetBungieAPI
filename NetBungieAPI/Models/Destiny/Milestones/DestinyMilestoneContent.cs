using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    /// <summary>
    ///     Represents localized, extended content related to Milestones. This is intentionally returned by a separate endpoint
    ///     and not with Character-level Milestone data because we do not put localized data into standard Destiny responses,
    ///     both for brevity of response and for caching purposes. If you really need this data, hit the Milestone Content
    ///     endpoint.
    /// </summary>
    public sealed record DestinyMilestoneContent
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
        public ReadOnlyCollection<string> Tips { get; init; } = Defaults.EmptyReadOnlyCollection<string>();

        /// <summary>
        ///     If DPS has defined items related to this Milestone, they can categorize those items in the Firehose. That data will
        ///     then be returned as item categories here
        /// </summary>
        [JsonPropertyName("itemCategories")]
        public ReadOnlyCollection<DestinyMilestoneContentItemCategory> ItemCategories { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyMilestoneContentItemCategory>();
    }
}