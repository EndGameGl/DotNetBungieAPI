using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Sockets;

public sealed class DestinySocketTypeDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("insertAction")]
    public Destiny.Definitions.Sockets.DestinyInsertPlugActionDefinition InsertAction { get; init; }

    [JsonPropertyName("plugWhitelist")]
    public List<Destiny.Definitions.Sockets.DestinyPlugWhitelistEntryDefinition> PlugWhitelist { get; init; }

    [JsonPropertyName("socketCategoryHash")]
    public uint SocketCategoryHash { get; init; }

    [JsonPropertyName("visibility")]
    public Destiny.DestinySocketVisibility Visibility { get; init; }

    [JsonPropertyName("alwaysRandomizeSockets")]
    public bool AlwaysRandomizeSockets { get; init; }

    [JsonPropertyName("isPreviewEnabled")]
    public bool IsPreviewEnabled { get; init; }

    [JsonPropertyName("hideDuplicateReusablePlugs")]
    public bool HideDuplicateReusablePlugs { get; init; }

    [JsonPropertyName("overridesUiAppearance")]
    public bool OverridesUiAppearance { get; init; }

    [JsonPropertyName("avoidDuplicatesOnInitialization")]
    public bool AvoidDuplicatesOnInitialization { get; init; }

    [JsonPropertyName("currencyScalars")]
    public List<Destiny.Definitions.Sockets.DestinySocketTypeScalarMaterialRequirementEntry> CurrencyScalars { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
