namespace DotNetBungieAPI.Models;

public sealed class DictionaryComponentResponseOfint32AndDestinyItemPlugObjectivesComponent
{
    [JsonPropertyName("data")]
    public Dictionary<int, Destiny.Components.Items.DestinyItemPlugObjectivesComponent>? Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
