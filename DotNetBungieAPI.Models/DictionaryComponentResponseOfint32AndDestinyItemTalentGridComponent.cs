namespace DotNetBungieAPI.Models;

public sealed class DictionaryComponentResponseOfint32AndDestinyItemTalentGridComponent
{
    [JsonPropertyName("data")]
    public Dictionary<int, Destiny.Entities.Items.DestinyItemTalentGridComponent>? Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
