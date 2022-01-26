namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Seasons;

/// <summary>
///     Defines the promotional text, images, and links to preview this season.
/// </summary>
public class DestinySeasonPreviewDefinition : IDeepEquatable<DestinySeasonPreviewDefinition>
{
    /// <summary>
    ///     A localized description of the season.
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    ///     A relative path to learn more about the season. Web browsers should be automatically redirected to the user's Bungie.net locale. For example: "/SeasonOfTheChosen" will redirect to "/7/en/Seasons/SeasonOfTheChosen" for English users.
    /// </summary>
    [JsonPropertyName("linkPath")]
    public string LinkPath { get; set; }

    /// <summary>
    ///     An optional link to a localized video, probably YouTube.
    /// </summary>
    [JsonPropertyName("videoLink")]
    public string VideoLink { get; set; }

    /// <summary>
    ///     A list of images to preview the seasonal content. Should have at least three to show.
    /// </summary>
    [JsonPropertyName("images")]
    public List<Destiny.Definitions.Seasons.DestinySeasonPreviewImageDefinition> Images { get; set; }

    public bool DeepEquals(DestinySeasonPreviewDefinition? other)
    {
        return other is not null &&
               Description == other.Description &&
               LinkPath == other.LinkPath &&
               VideoLink == other.VideoLink &&
               Images.DeepEqualsList(other.Images);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinySeasonPreviewDefinition? other)
    {
        if (other is null) return;
        if (Description != other.Description)
        {
            Description = other.Description;
            OnPropertyChanged(nameof(Description));
        }
        if (LinkPath != other.LinkPath)
        {
            LinkPath = other.LinkPath;
            OnPropertyChanged(nameof(LinkPath));
        }
        if (VideoLink != other.VideoLink)
        {
            VideoLink = other.VideoLink;
            OnPropertyChanged(nameof(VideoLink));
        }
        if (!Images.DeepEqualsList(other.Images))
        {
            Images = other.Images;
            OnPropertyChanged(nameof(Images));
        }
    }
}