namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Craftables;

public class DestinyCraftableComponent
{
    [JsonPropertyName("visible")]
    public bool? Visible { get; set; }

    /// <summary>
    ///     If the requirements are not met for crafting this item, these will index into the list of failure strings.
    /// </summary>
    [JsonPropertyName("failedRequirementIndexes")]
    public List<int> FailedRequirementIndexes { get; set; }

    /// <summary>
    ///     Plug item state for the crafting sockets.
    /// </summary>
    [JsonPropertyName("sockets")]
    public List<Destiny.Components.Craftables.DestinyCraftableSocketComponent> Sockets { get; set; }
}
