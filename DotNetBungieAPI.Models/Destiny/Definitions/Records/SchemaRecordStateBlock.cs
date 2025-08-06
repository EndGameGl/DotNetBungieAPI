namespace DotNetBungieAPI.Models.Destiny.Definitions.Records;

public sealed class SchemaRecordStateBlock
{
    [JsonPropertyName("featuredPriority")]
    public int FeaturedPriority { get; init; }

    /// <summary>
    ///     A display name override to show when this record is 'obscured' instead of the default obscured display name.
    /// </summary>
    [JsonPropertyName("obscuredName")]
    public string ObscuredName { get; init; }

    /// <summary>
    ///     A display description override to show when this record is 'obscured' instead of the default obscured display description.
    /// </summary>
    [JsonPropertyName("obscuredDescription")]
    public string ObscuredDescription { get; init; }
}
