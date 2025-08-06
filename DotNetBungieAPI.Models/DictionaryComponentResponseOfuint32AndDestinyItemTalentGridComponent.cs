namespace DotNetBungieAPI.Models;

public sealed class DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponent
{
    [JsonPropertyName("data")]
    public Dictionary<uint, Destiny.Entities.Items.DestinyItemTalentGridComponent>? Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
