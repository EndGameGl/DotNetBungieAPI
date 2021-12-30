using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

public sealed class DestinyDerivedItemCategoryDefinition
{

    [JsonPropertyName("categoryDescription")]
    public string CategoryDescription { get; init; }

    [JsonPropertyName("items")]
    public List<Destiny.Definitions.Items.DestinyDerivedItemDefinition> Items { get; init; }
}
