namespace DotNetBungieAPI.Models;

public sealed class SingleComponentResponseOfDestinyCharacterRenderComponent
{
    [JsonPropertyName("data")]
    public Destiny.Entities.Characters.DestinyCharacterRenderComponent? Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
