using DotNetBungieAPI.Service.Abstractions;

namespace DotNetBungieAPI;

internal static class BungieClientInstance
{
    internal static IBungieClient BungieClient { get; set; }
}
