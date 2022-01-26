namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     Represents a season and the number of resets you had in that season.
/// <para />
///      We do not necessarily - even for progressions with resets - track it over all seasons. So be careful and check the season numbers being returned.
/// </summary>
public class DestinyProgressionResetEntry : IDeepEquatable<DestinyProgressionResetEntry>
{
    [JsonPropertyName("season")]
    public int Season { get; set; }

    [JsonPropertyName("resets")]
    public int Resets { get; set; }

    public bool DeepEquals(DestinyProgressionResetEntry? other)
    {
        return other is not null &&
               Season == other.Season &&
               Resets == other.Resets;
    }
}