namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Reporting;

/// <summary>
///     A specific reason for being banned. Only accessible under the related category (DestinyReportReasonCategoryDefinition) under which it is shown. Note that this means that report reasons' reasonHash are not globally unique: and indeed, entries like "Other" are defined under most categories for example.
/// </summary>
public class DestinyReportReasonDefinition
{
    /// <summary>
    ///     The identifier for the reason: they are only guaranteed unique under the Category in which they are found.
    /// </summary>
    [JsonPropertyName("reasonHash")]
    public uint? ReasonHash { get; set; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }
}
