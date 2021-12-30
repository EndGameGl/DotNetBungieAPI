using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemPreviewBlockDefinition
{

    [JsonPropertyName("screenStyle")]
    public string ScreenStyle { get; init; }

    [JsonPropertyName("previewVendorHash")]
    public uint PreviewVendorHash { get; init; }

    [JsonPropertyName("artifactHash")]
    public uint? ArtifactHash { get; init; }

    [JsonPropertyName("previewActionString")]
    public string PreviewActionString { get; init; }

    [JsonPropertyName("derivedItemCategories")]
    public List<Destiny.Definitions.Items.DestinyDerivedItemCategoryDefinition> DerivedItemCategories { get; init; }
}
