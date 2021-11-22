namespace DotNetBungieAPI.Models.Destiny.Definitions.Seasons
{
    /// <summary>
    ///     Defines the promotional text, images, and links to preview this season.
    /// </summary>
    public sealed record DestinySeasonPreviewDefinition : IDeepEquatable<DestinySeasonPreviewDefinition>
    {
        /// <summary>
        ///     A localized description of the season.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; init; }

        /// <summary>
        ///     A relative path to learn more about the season. Web browsers should be automatically redirected to the user's
        ///     Bungie.net locale.
        /// </summary>
        [JsonPropertyName("linkPath")]
        public BungieNetResource LinkPath { get; init; }

        /// <summary>
        ///     An optional link to a localized video, probably YouTube.
        /// </summary>
        [JsonPropertyName("videoLink")]
        public BungieNetResource VideoLink { get; init; }

        /// <summary>
        ///     A list of images to preview the seasonal content. Should have at least three to show.
        /// </summary>
        [JsonPropertyName("images")]
        public ReadOnlyCollection<DestinySeasonPreviewImageDefinition> Images { get; init; } =
            ReadOnlyCollections<DestinySeasonPreviewImageDefinition>.Empty;

        public bool DeepEquals(DestinySeasonPreviewDefinition other)
        {
            return other != null &&
                   Description == other.Description &&
                   LinkPath == other.LinkPath &&
                   VideoLink == other.VideoLink &&
                   Images.DeepEqualsReadOnlyCollections(other.Images);
        }
    }
}