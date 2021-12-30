using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Seasons;

/// <summary>
///     Defines the promotional text, images, and links to preview this season.
/// </summary>
public sealed class DestinySeasonPreviewDefinition
{

    /// <summary>
    ///     A localized description of the season.
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; init; }

    /// <summary>
    ///     A relative path to learn more about the season. Web browsers should be automatically redirected to the user's Bungie.net locale. For example: "/SeasonOfTheChosen" will redirect to "/7/en/Seasons/SeasonOfTheChosen" for English users.
    /// </summary>
    [JsonPropertyName("linkPath")]
    public string LinkPath { get; init; }

    /// <summary>
    ///     An optional link to a localized video, probably YouTube.
    /// </summary>
    [JsonPropertyName("videoLink")]
    public string VideoLink { get; init; }

    /// <summary>
    ///     A list of images to preview the seasonal content. Should have at least three to show.
    /// </summary>
    [JsonPropertyName("images")]
    public List<Destiny.Definitions.Seasons.DestinySeasonPreviewImageDefinition> Images { get; init; }
}
