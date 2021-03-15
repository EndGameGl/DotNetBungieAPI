using NetBungieAPI.Clients;
using NetBungieAPI.Clients.Settings;

namespace NetBungieAPI.Services
{
    public interface IConfigurationService
    {
        BungieClientSettings Settings { get; }
        void ApplySettings(BungieClientSettings settings);
        void ApplySettingsFromConfig(string filePath);
    }
}
