namespace DotNetBungieAPI.Generated.Models;

public class DestinyBaseItemComponentSetOfint64
{
    [JsonPropertyName("objectives")]
    public DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent Objectives { get; set; }

    [JsonPropertyName("perks")]
    public DictionaryComponentResponseOfint64AndDestinyItemPerksComponent Perks { get; set; }
}
