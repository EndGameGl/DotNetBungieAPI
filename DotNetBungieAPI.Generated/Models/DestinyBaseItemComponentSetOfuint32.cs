using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public sealed class DestinyBaseItemComponentSetOfuint32
{

    [JsonPropertyName("objectives")]
    public DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent Objectives { get; init; }

    [JsonPropertyName("perks")]
    public DictionaryComponentResponseOfuint32AndDestinyItemPerksComponent Perks { get; init; }
}
