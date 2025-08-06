namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     The results of a bulk Equipping operation performed through the Destiny API.
/// </summary>
public sealed class DestinyEquipItemResults
{
    [JsonPropertyName("equipResults")]
    public Destiny.DestinyEquipItemResult[]? EquipResults { get; init; }
}
