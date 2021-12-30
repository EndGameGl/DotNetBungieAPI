using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.User;

public sealed class EMailSettingLocalization
{

    [JsonPropertyName("title")]
    public string Title { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }
}
