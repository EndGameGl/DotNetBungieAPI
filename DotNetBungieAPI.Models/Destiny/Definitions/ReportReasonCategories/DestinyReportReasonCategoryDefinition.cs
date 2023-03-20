using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.ReportReasonCategories;

/// <summary>
///     If you're going to report someone for a Terms of Service violation, you need to choose a category and reason for
///     the report. This definition holds both the categories and the reasons within those categories, for simplicity and
///     my own laziness' sake.
///     <para />
///     Note tha this means that, to refer to a Reason by reasonHash, you need a combination of the reasonHash *and* the
///     associated ReasonCategory's hash: there are some reasons defined under multiple categories.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyReportReasonCategoryDefinition)]
public sealed record DestinyReportReasonCategoryDefinition : IDestinyDefinition, IDisplayProperties,
    IDeepEquatable<DestinyReportReasonCategoryDefinition>
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     The specific reasons for the report under this category.
    /// </summary>
    [JsonPropertyName("reasons")]
    public ReadOnlyDictionary<uint, DestinyReportReasonDefinition> Reasons { get; init; } =
        ReadOnlyDictionaries<uint, DestinyReportReasonDefinition>.Empty;

    public bool DeepEquals(DestinyReportReasonCategoryDefinition other)
    {
        return other != null &&
               DisplayProperties.DeepEquals(other.DisplayProperties) &&
               Reasons.DeepEqualsReadOnlyDictionaryWithSimpleKeyAndEquatableValue(other.Reasons) &&
               Blacklisted == other.Blacklisted &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyReportReasonCategoryDefinition;
    [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
    [JsonPropertyName("hash")] public uint Hash { get; init; }
    [JsonPropertyName("index")] public int Index { get; init; }
    [JsonPropertyName("redacted")] public bool Redacted { get; init; }
}