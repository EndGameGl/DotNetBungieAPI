namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Activities;

public class DestinyActivitySkullOption
{
    [JsonPropertyName("optionHash")]
    public uint OptionHash { get; set; }

    [JsonPropertyName("stringValue")]
    public string StringValue { get; set; }

    [JsonPropertyName("boolValue")]
    public bool BoolValue { get; set; }

    [JsonPropertyName("integerValue")]
    public int IntegerValue { get; set; }

    [JsonPropertyName("floatValue")]
    public float? FloatValue { get; set; }

    [JsonPropertyName("minDisplayDifficultyId")]
    public Destiny.DestinyActivityDifficultyId MinDisplayDifficultyId { get; set; }
}
