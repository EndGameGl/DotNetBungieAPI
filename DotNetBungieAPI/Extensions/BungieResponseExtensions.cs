using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Exceptions;

namespace DotNetBungieAPI.Extensions;

public static class BungieResponseExtensions
{
    public static BungieResponseErrorException ToException<T>(this BungieResponse<T> response) =>
        new(
            response.ErrorCode,
            response.ErrorStatus,
            response.Message,
            response.MessageData);
}