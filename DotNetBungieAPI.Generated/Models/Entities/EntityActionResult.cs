using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Entities;

public sealed class EntityActionResult
{

    [JsonPropertyName("entityId")]
    public long EntityId { get; init; }

    [JsonPropertyName("result")]
    public Exceptions.PlatformErrorCodes Result { get; init; }
}
