namespace DotNetBungieAPI.Models;

public sealed class DestinyBaseItemComponentSetOfint32
{
    [JsonPropertyName("objectives")]
    public DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent? Objectives { get; init; }

    [JsonPropertyName("perks")]
    public DictionaryComponentResponseOfint32AndDestinyItemPerksComponent? Perks { get; init; }
}
