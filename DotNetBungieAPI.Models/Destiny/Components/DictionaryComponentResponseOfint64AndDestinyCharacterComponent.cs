namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyCharacterComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyCharacterComponent> Data { get; init; } =
        ReadOnlyDictionary<long, DestinyCharacterComponent>.Empty;

    /// <summary>
    ///     Returns last played character from this account
    /// </summary>
    /// <returns></returns>
    public DestinyCharacterComponent GetLastPlayedCharacter()
    {
        long biggestDateId = 0;
        var biggestDate = DateTime.MinValue;
        foreach (var (key, value) in Data)
            if (value.DateLastPlayed > biggestDate)
            {
                biggestDate = value.DateLastPlayed;
                biggestDateId = key;
            }

        return Data[biggestDateId];
    }

    /// <summary>
    ///     Returns most played character from this account
    /// </summary>
    /// <returns></returns>
    public DestinyCharacterComponent GetMostPlayedCharacter()
    {
        long longestPlayedId = 0;
        long longestPlayed = 0;
        foreach (var (key, value) in Data)
            if (value.MinutesPlayedTotal > longestPlayed)
            {
                longestPlayed = value.MinutesPlayedTotal;
                longestPlayedId = key;
            }

        return Data[longestPlayedId];
    }

    /// <summary>
    ///     Returns character with highest light from this account
    /// </summary>
    /// <returns></returns>
    public DestinyCharacterComponent GetHighestLightCharacter()
    {
        long id = 0;
        var highestLight = 0;
        foreach (var (key, value) in Data)
            if (value.Light > highestLight)
            {
                highestLight = value.Light;
                id = key;
            }

        return Data[id];
    }
}
