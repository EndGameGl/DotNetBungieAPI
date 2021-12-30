using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public sealed class SingleComponentResponseOfDestinyCharacterProgressionComponent
{

    [JsonPropertyName("data")]
    public Destiny.Entities.Characters.DestinyCharacterProgressionComponent Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
