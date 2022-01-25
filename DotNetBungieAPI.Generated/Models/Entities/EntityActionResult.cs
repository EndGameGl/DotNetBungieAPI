namespace DotNetBungieAPI.Generated.Models.Entities;

public class EntityActionResult
{
    [JsonPropertyName("entityId")]
    public long EntityId { get; set; }

    [JsonPropertyName("result")]
    public Exceptions.PlatformErrorCodes Result { get; set; }
}
