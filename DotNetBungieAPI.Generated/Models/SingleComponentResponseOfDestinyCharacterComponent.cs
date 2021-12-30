using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public sealed class SingleComponentResponseOfDestinyCharacterComponent
{

    [JsonPropertyName("data")]
    public Destiny.Entities.Characters.DestinyCharacterComponent Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
