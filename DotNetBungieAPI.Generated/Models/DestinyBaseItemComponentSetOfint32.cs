namespace DotNetBungieAPI.Generated.Models;

public class DestinyBaseItemComponentSetOfint32
{
    [JsonPropertyName("objectives")]
    public DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent Objectives { get; set; }

    [JsonPropertyName("perks")]
    public DictionaryComponentResponseOfint32AndDestinyItemPerksComponent Perks { get; set; }
}
