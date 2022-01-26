namespace DotNetBungieAPI.Generated.Models;

public class DictionaryComponentResponseOfint64AndDestinyCharacterActivitiesComponent : IDeepEquatable<DictionaryComponentResponseOfint64AndDestinyCharacterActivitiesComponent>
{
    [JsonPropertyName("data")]
    public Dictionary<long, Destiny.Entities.Characters.DestinyCharacterActivitiesComponent> Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    public bool DeepEquals(DictionaryComponentResponseOfint64AndDestinyCharacterActivitiesComponent? other)
    {
        return other is not null &&
               Data.DeepEqualsDictionary(other.Data) &&
               Privacy == other.Privacy &&
               Disabled == other.Disabled;
    }
}