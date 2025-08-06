namespace DotNetBungieAPI.Models;

public sealed class DictionaryComponentResponseOfint64AndDestinyLoadoutsComponent
{
    [JsonPropertyName("data")]
    public Dictionary<long, Destiny.Components.Loadouts.DestinyLoadoutsComponent>? Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
