using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Applications
{
    public sealed record Series
    {
        [JsonPropertyName("datapoints")]
        public ReadOnlyCollection<Datapoint> Datapoints { get; init; } = Defaults.EmptyReadOnlyCollection<Datapoint>();

        [JsonPropertyName("target")]
        public string Target { get; init; }

    }
}
