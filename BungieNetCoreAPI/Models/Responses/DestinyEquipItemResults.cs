using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Responses
{
    public sealed record DestinyEquipItemResults
    {
        [JsonPropertyName("equipResults")]
        public ReadOnlyCollection<DestinyEquipItemResult> EquipResults { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyEquipItemResult>();
    }
}