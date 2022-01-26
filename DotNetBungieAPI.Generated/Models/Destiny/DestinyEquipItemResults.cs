namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     The results of a bulk Equipping operation performed through the Destiny API.
/// </summary>
public class DestinyEquipItemResults : IDeepEquatable<DestinyEquipItemResults>
{
    [JsonPropertyName("equipResults")]
    public List<Destiny.DestinyEquipItemResult> EquipResults { get; set; }

    public bool DeepEquals(DestinyEquipItemResults? other)
    {
        return other is not null &&
               EquipResults.DeepEqualsList(other.EquipResults);
    }
}