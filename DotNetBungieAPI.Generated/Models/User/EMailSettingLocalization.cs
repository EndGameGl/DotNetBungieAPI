namespace DotNetBungieAPI.Generated.Models.User;

/// <summary>
///     Localized text relevant to a given EMail setting in a given localization.
/// </summary>
public class EMailSettingLocalization
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}
