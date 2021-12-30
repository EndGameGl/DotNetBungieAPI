using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemCategoryDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("visible")]
    public bool Visible { get; init; }

    [JsonPropertyName("deprecated")]
    public bool Deprecated { get; init; }

    [JsonPropertyName("shortTitle")]
    public string ShortTitle { get; init; }

    [JsonPropertyName("itemTypeRegex")]
    public string ItemTypeRegex { get; init; }

    [JsonPropertyName("grantDestinyBreakerType")]
    public Destiny.DestinyBreakerType GrantDestinyBreakerType { get; init; }

    [JsonPropertyName("plugCategoryIdentifier")]
    public string PlugCategoryIdentifier { get; init; }

    [JsonPropertyName("itemTypeRegexNot")]
    public string ItemTypeRegexNot { get; init; }

    [JsonPropertyName("originBucketIdentifier")]
    public string OriginBucketIdentifier { get; init; }

    [JsonPropertyName("grantDestinyItemType")]
    public Destiny.DestinyItemType GrantDestinyItemType { get; init; }

    [JsonPropertyName("grantDestinySubType")]
    public Destiny.DestinyItemSubType GrantDestinySubType { get; init; }

    [JsonPropertyName("grantDestinyClass")]
    public Destiny.DestinyClass GrantDestinyClass { get; init; }

    [JsonPropertyName("traitId")]
    public string TraitId { get; init; }

    [JsonPropertyName("groupedCategoryHashes")]
    public List<uint> GroupedCategoryHashes { get; init; }

    [JsonPropertyName("parentCategoryHashes")]
    public List<uint> ParentCategoryHashes { get; init; }

    [JsonPropertyName("groupCategoryOnly")]
    public bool GroupCategoryOnly { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
