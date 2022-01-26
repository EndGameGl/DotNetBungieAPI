namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public class SchemaRecordStateBlock : IDeepEquatable<SchemaRecordStateBlock>
{
    [JsonPropertyName("featuredPriority")]
    public int FeaturedPriority { get; set; }

    [JsonPropertyName("obscuredString")]
    public string ObscuredString { get; set; }

    public bool DeepEquals(SchemaRecordStateBlock? other)
    {
        return other is not null &&
               FeaturedPriority == other.FeaturedPriority &&
               ObscuredString == other.ObscuredString;
    }
}