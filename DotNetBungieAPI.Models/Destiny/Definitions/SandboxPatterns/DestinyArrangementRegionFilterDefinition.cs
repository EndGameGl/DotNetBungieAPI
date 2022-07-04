namespace DotNetBungieAPI.Models.Destiny.Definitions.SandboxPatterns;

public sealed record DestinyArrangementRegionFilterDefinition : IDeepEquatable<DestinyArrangementRegionFilterDefinition>
{
    [JsonPropertyName("artArrangementRegionHash")]
    public uint ArtArrangementRegionHash { get; init; }

    [JsonPropertyName("artArrangementRegionIndex")]
    public int ArtArrangementRegionIndex { get; init; }

    [JsonPropertyName("statHash")] 
    public uint Stat { get; init; }
    
    [JsonPropertyName("arrangementIndexByStatValue")]
    public ReadOnlyDictionary<int, int> ArrangementIndexByStatValue { get; init; } =
        ReadOnlyDictionaries<int, int>.Empty;

    public bool DeepEquals(DestinyArrangementRegionFilterDefinition other)
    {
        return other != null &&
               ArrangementIndexByStatValue.DeepEqualsReadOnlyDictionaryWithSimpleKeyAndSimpleValue(
                   other.ArrangementIndexByStatValue) &&
               ArtArrangementRegionHash == other.ArtArrangementRegionHash &&
               ArtArrangementRegionIndex == other.ArtArrangementRegionIndex &&
               Stat == other.Stat;
    }
}