using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Sockets;

public sealed class DestinyInsertPlugActionDefinition
{

    [JsonPropertyName("actionExecuteSeconds")]
    public int ActionExecuteSeconds { get; init; }

    [JsonPropertyName("actionType")]
    public Destiny.SocketTypeActionType ActionType { get; init; }
}
