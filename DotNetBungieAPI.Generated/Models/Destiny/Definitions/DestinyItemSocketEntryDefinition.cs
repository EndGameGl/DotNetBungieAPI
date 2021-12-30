using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemSocketEntryDefinition
{

    [JsonPropertyName("socketTypeHash")]
    public uint SocketTypeHash { get; init; }

    [JsonPropertyName("singleInitialItemHash")]
    public uint SingleInitialItemHash { get; init; }

    [JsonPropertyName("reusablePlugItems")]
    public List<Destiny.Definitions.DestinyItemSocketEntryPlugItemDefinition> ReusablePlugItems { get; init; }

    [JsonPropertyName("preventInitializationOnVendorPurchase")]
    public bool PreventInitializationOnVendorPurchase { get; init; }

    [JsonPropertyName("hidePerksInItemTooltip")]
    public bool HidePerksInItemTooltip { get; init; }

    [JsonPropertyName("plugSources")]
    public Destiny.SocketPlugSources PlugSources { get; init; }

    [JsonPropertyName("reusablePlugSetHash")]
    public uint? ReusablePlugSetHash { get; init; }

    [JsonPropertyName("randomizedPlugSetHash")]
    public uint? RandomizedPlugSetHash { get; init; }

    [JsonPropertyName("defaultVisible")]
    public bool DefaultVisible { get; init; }
}
