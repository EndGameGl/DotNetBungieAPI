namespace DotNetBungieAPI.Models.Dates;

public sealed record DateRange : IDeepEquatable<DateRange>
{
    [JsonPropertyName("start")]
    public DateTime Start { get; init; }

    [JsonPropertyName("end")]
    public DateTime End { get; init; }

    public bool DeepEquals(DateRange other)
    {
        return other != null && Start.Equals(other.Start) && End.Equals(other.End);
    }
}
