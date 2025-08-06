namespace DotNetBungieAPI.Models.Destiny.Components.Craftables;

public sealed class DestinyCraftableComponent
{
    [JsonPropertyName("visible")]
    public bool Visible { get; init; }

    /// <summary>
    ///     If the requirements are not met for crafting this item, these will index into the list of failure strings.
    /// </summary>
    [JsonPropertyName("failedRequirementIndexes")]
    public int[]? FailedRequirementIndexes { get; init; }

    /// <summary>
    ///     Plug item state for the crafting sockets.
    /// </summary>
    [JsonPropertyName("sockets")]
    public Destiny.Components.Craftables.DestinyCraftableSocketComponent[]? Sockets { get; init; }
}
