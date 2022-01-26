namespace DotNetBungieAPI.Generated.Models.Dates;

public class DateRange : IDeepEquatable<DateRange>
{
    [JsonPropertyName("start")]
    public DateTime Start { get; set; }

    [JsonPropertyName("end")]
    public DateTime End { get; set; }

    public bool DeepEquals(DateRange? other)
    {
        return other is not null &&
               Start == other.Start &&
               End == other.End;
    }
}