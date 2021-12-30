using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Dates;

public sealed class DateRange
{

    [JsonPropertyName("start")]
    public DateTime Start { get; init; }

    [JsonPropertyName("end")]
    public DateTime End { get; init; }
}
