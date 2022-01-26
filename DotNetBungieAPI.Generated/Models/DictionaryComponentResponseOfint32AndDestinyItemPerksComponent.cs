namespace DotNetBungieAPI.Generated.Models;

public class DictionaryComponentResponseOfint32AndDestinyItemPerksComponent : IDeepEquatable<DictionaryComponentResponseOfint32AndDestinyItemPerksComponent>
{
    [JsonPropertyName("data")]
    public Dictionary<int, Destiny.Entities.Items.DestinyItemPerksComponent> Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    public bool DeepEquals(DictionaryComponentResponseOfint32AndDestinyItemPerksComponent? other)
    {
        return other is not null &&
               Data.DeepEqualsDictionary(other.Data) &&
               Privacy == other.Privacy &&
               Disabled == other.Disabled;
    }
}