using BungieNetCoreAPI.Clients;

namespace BungieNetCoreAPI.Services
{
    public interface IConfigurationService
    {
        BungieClientSettings Settings { get; }
        void ApplySettings(BungieClientSettings settings);
    }
}
