namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     The results of a bulk Equipping operation performed through the Destiny API.
/// </summary>
public class DestinyEquipItemResults
{
    [JsonPropertyName("equipResults")]
    public List<Destiny.DestinyEquipItemResult> EquipResults { get; set; }
}
