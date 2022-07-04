using DotNetBungieAPI.Exceptions;
using DotNetBungieAPI.Models;

namespace DotNetBungieAPI.Extensions;

public static class BungieResponseExtensions
{
    public static BungieResponseErrorException ToException<T>(this BungieResponse<T> response) =>
        new BungieResponseErrorException(
            response.ErrorCode, 
            response.ErrorStatus, 
            response.Message, 
            response.MessageData);
}