using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyStringVariablesComponent
    {
        [JsonPropertyName("integerValuesByHash")]
        public ReadOnlyDictionary<uint, int> IntegerValuesByHash { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, int>();
    }
}