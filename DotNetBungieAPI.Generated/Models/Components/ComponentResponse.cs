using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Components;

public sealed class ComponentResponse
{

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
