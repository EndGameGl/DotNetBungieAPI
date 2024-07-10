namespace DotNetBungieAPI.Models.Trending;

/// <summary>
///     The list entry view for trending items. Returns just enough to show the item on the trending page.
/// </summary>
public sealed record TrendingEntry
{
    /// <summary>
    ///     The weighted score of this trending item.
    /// </summary>
    [JsonPropertyName("weight")]
    public double Weight { get; init; }

    [JsonPropertyName("isFeatured")]
    public bool IsFeatured { get; init; }

    /// <summary>
    ///     We don't know whether the identifier will be a string, a uint, or a long... so we're going to cast it all to a
    ///     string. But either way, we need any trending item created to have a single unique identifier for its type.
    /// </summary>
    [JsonPropertyName("identifier")]
    public string Identifier { get; init; }

    /// <summary>
    ///     An enum - unfortunately - dictating all of the possible kinds of trending items that you might get in your result
    ///     set, in case you want to do custom rendering or call to get the details of the item.
    /// </summary>
    [JsonPropertyName("entityType")]
    public TrendingEntryType EntityType { get; init; }

    /// <summary>
    ///     The localized "display name/article title/'primary localized identifier'" of the entity.
    /// </summary>
    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; }

    /// <summary>
    ///     If the entity has a localized tagline/subtitle/motto/whatever, that is found here.
    /// </summary>
    [JsonPropertyName("tagline")]
    public string Tagline { get; init; }

    [JsonPropertyName("image")]
    public string Image { get; init; }

    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; init; }

    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [JsonPropertyName("link")]
    public string Link { get; init; }

    /// <summary>
    ///     If this is populated, the entry has a related WebM video to show. I am 100% certain I am going to regret putting
    ///     this directly on TrendingEntry, but it will work so yolo
    /// </summary>
    [JsonPropertyName("webmVideo")]
    public string WebmVideo { get; init; }

    /// <summary>
    ///     If this is populated, the entry has a related MP4 video to show. I am 100% certain I am going to regret putting
    ///     this directly on TrendingEntry, but it will work so yolo
    /// </summary>
    [JsonPropertyName("mp4Video")]
    public string Mp4Video { get; init; }

    /// <summary>
    ///     If isFeatured, this image will be populated with whatever the featured image is. Note that this will likely be a
    ///     very large image, so don't use it all the time.
    /// </summary>
    [JsonPropertyName("featureImage")]
    public string FeatureImage { get; init; }

    /// <summary>
    ///     If the item is of entityType TrendingEntryType.Container, it may have items - also Trending Entries - contained
    ///     within it. This is the ordered list of those to display under the Container's header.
    /// </summary>
    [JsonPropertyName("items")]
    public ReadOnlyCollection<TrendingEntry> Items { get; init; } =
        ReadOnlyCollections<TrendingEntry>.Empty;

    /// <summary>
    ///     If the entry has a date at which it was created, this is that date.
    /// </summary>
    [JsonPropertyName("creationDate")]
    public DateTime? CreationDate { get; init; }
}
