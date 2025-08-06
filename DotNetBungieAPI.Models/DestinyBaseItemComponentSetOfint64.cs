namespace DotNetBungieAPI.Models;

public sealed class DestinyBaseItemComponentSetOfint64
{
    [JsonPropertyName("objectives")]
    public DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent? Objectives { get; init; }

    [JsonPropertyName("perks")]
    public DictionaryComponentResponseOfint64AndDestinyItemPerksComponent? Perks { get; init; }
}
