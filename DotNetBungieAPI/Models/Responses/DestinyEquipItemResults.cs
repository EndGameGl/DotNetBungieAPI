namespace DotNetBungieAPI.Models.Responses
{
    /// <summary>
    ///     The results of a bulk Equipping operation performed through the Destiny API.
    /// </summary>
    public sealed record DestinyEquipItemResults
    {
        [JsonPropertyName("equipResults")]
        public ReadOnlyCollection<DestinyEquipItemResult> EquipResults { get; init; } =
            ReadOnlyCollections<DestinyEquipItemResult>.Empty;
    }
}