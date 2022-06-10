namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Craftables;

public class DestinyCraftableSocketPlugComponent
{
    [JsonPropertyName("plugItemHash")]
    public uint? PlugItemHash { get; set; }

    /// <summary>
    ///     Index into the unlock requirements to display failure descriptions
    /// </summary>
    [JsonPropertyName("failedRequirementIndexes")]
    public List<int> FailedRequirementIndexes { get; set; }
}
