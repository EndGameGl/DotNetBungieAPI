using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.User;

/// <summary>
///     Localized text relevant to a given EMail setting in a given localization.
/// </summary>
public sealed class EMailSettingLocalization
{

    [JsonPropertyName("title")]
    public string Title { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }
}
