using System;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Providers;

namespace NetBungieAPI.Clients.Settings
{
    public class DefinitionLoadingSettings
    {
        public int AppConcurrencyLevel { get; internal set; }
        public BungieLocales[] Locales { get; internal set; }
        public bool PremapDefinitionPointers { get; internal set; }
        public bool LoadAllDefinitionsOnStatup { get; internal set; }
        public DefinitionProvider UsedProvider { get; internal set; }
        public DefinitionsEnum[] AllowedDefinitions { get; internal set; }
        public DefinitionsEnum[] ForbiddenDefinitions { get; internal set; }
        public bool WaitAllDefinitionsToLoad { get; internal set; }
        public bool DownloadLatestManifestOnLoad { get; internal set; }

        public static DefinitionLoadingSettings Default => new DefinitionLoadingSettings()
        {
            AppConcurrencyLevel = Environment.ProcessorCount * 2,
            Locales = Array.Empty<BungieLocales>(),
            PremapDefinitionPointers = false,
            LoadAllDefinitionsOnStatup = false,
            UsedProvider = null,
            AllowedDefinitions = Array.Empty<DefinitionsEnum>(),
            ForbiddenDefinitions = Array.Empty<DefinitionsEnum>(),
            WaitAllDefinitionsToLoad = true,
            DownloadLatestManifestOnLoad = true
        };
    }
}