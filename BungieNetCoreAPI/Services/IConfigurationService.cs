using NetBungieApi.Clients;
using NetBungieApi.Clients.Settings;

namespace NetBungieApi.Services
{
    public interface IConfigurationService
    {
        BungieClientSettings Settings { get; }
        void ApplySettings(BungieClientSettings settings);
        void ApplySettingsFromConfig(string filePath);
    }
}
