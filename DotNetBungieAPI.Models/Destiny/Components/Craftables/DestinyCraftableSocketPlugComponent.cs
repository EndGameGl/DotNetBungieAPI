namespace DotNetBungieAPI.Models.Destiny.Components.Craftables;

public sealed class DestinyCraftableSocketPlugComponent
{
    [JsonPropertyName("plugItemHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition> PlugItemHash { get; init; }

    /// <summary>
    ///     Index into the unlock requirements to display failure descriptions
    /// </summary>
    [JsonPropertyName("failedRequirementIndexes")]
    public int[]? FailedRequirementIndexes { get; init; }
}
