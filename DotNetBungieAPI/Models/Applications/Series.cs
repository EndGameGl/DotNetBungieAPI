using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Applications
{
    public sealed record Series
    {
        /// <summary>
        ///     Collection of samples with time and value.
        /// </summary>
        [JsonPropertyName("datapoints")]
        public ReadOnlyCollection<Datapoint> Datapoints { get; init; } = Defaults.EmptyReadOnlyCollection<Datapoint>();

        /// <summary>
        ///     Target to which to datapoints apply.
        /// </summary>
        [JsonPropertyName("target")]
        public string Target { get; init; }
    }
}