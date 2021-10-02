using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Common
{
    public sealed record CoreSystem
    {
        [JsonPropertyName("enabled")] public bool IsEnabled { get; init; }

        [JsonPropertyName("parameters")]
        public ReadOnlyDictionary<string, string> Parameters { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, string>();
    }
}