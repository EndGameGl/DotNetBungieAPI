using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.User;

public sealed class EmailViewDefinition
{

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("viewSettings")]
    public List<User.EmailViewDefinitionSetting> ViewSettings { get; init; }
}
