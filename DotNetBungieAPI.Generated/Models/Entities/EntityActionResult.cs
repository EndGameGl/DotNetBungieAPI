namespace DotNetBungieAPI.Generated.Models.Entities;

public class EntityActionResult : IDeepEquatable<EntityActionResult>
{
    [JsonPropertyName("entityId")]
    public long EntityId { get; set; }

    [JsonPropertyName("result")]
    public Exceptions.PlatformErrorCodes Result { get; set; }

    public bool DeepEquals(EntityActionResult? other)
    {
        return other is not null &&
               EntityId == other.EntityId &&
               Result == other.Result;
    }
}