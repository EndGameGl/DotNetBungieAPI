namespace DotNetBungieAPI.Generated.Models;

public class DictionaryComponentResponseOfint64AndDestinyCharacterProgressionComponent : IDeepEquatable<DictionaryComponentResponseOfint64AndDestinyCharacterProgressionComponent>
{
    [JsonPropertyName("data")]
    public Dictionary<long, Destiny.Entities.Characters.DestinyCharacterProgressionComponent> Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    public bool DeepEquals(DictionaryComponentResponseOfint64AndDestinyCharacterProgressionComponent? other)
    {
        return other is not null &&
               Data.DeepEqualsDictionary(other.Data) &&
               Privacy == other.Privacy &&
               Disabled == other.Disabled;
    }
}