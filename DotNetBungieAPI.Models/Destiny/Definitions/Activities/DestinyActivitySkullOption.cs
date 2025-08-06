namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities;

public sealed class DestinyActivitySkullOption
{
    [JsonPropertyName("optionHash")]
    public uint OptionHash { get; init; }

    [JsonPropertyName("stringValue")]
    public string StringValue { get; init; }

    [JsonPropertyName("boolValue")]
    public bool BoolValue { get; init; }

    [JsonPropertyName("integerValue")]
    public int IntegerValue { get; init; }

    [JsonPropertyName("floatValue")]
    public float? FloatValue { get; init; }

    [JsonPropertyName("minDisplayDifficultyId")]
    public Destiny.DestinyActivityDifficultyId MinDisplayDifficultyId { get; init; }
}
