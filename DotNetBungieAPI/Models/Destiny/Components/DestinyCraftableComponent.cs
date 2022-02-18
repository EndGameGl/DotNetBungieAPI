namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DestinyCraftableComponent
{
    [JsonPropertyName("visible")] public bool Visible { get; init; }

    /// <summary>
    ///     If the requirements are not met for crafting this item, these will index into the list of failure strings.
    /// </summary>
    [JsonPropertyName("failedRequirementIndexes")]
    public ReadOnlyCollection<int> FailedRequirementIndexes { get; init; } = ReadOnlyCollections<int>.Empty;

    [JsonPropertyName("sockets")]
    public ReadOnlyCollection<DestinyCraftableSocketComponent> Sockets { get; init; } =
        ReadOnlyCollections<DestinyCraftableSocketComponent>.Empty;
}