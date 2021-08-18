using System;
using System.Collections.Concurrent;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Providers;

namespace NetBungieAPI.Clients.Settings
{
    /// <summary>
    /// Settings that are used for handling definition loading
    /// </summary>
    public class DefinitionLoadingSettings
    {
        /// <summary>
        /// Concurrency level that is user in <see cref="ConcurrentDictionary{TKey,TValue}"/> instances
        /// </summary>
        public int AppConcurrencyLevel { get; internal set; }

        /// <summary>
        /// Locales that are allowed to load
        /// </summary>
        public BungieLocales[] Locales { get; internal set; }

        /// <summary>
        /// Whether definition hash pointers should be premapped
        /// </summary>
        public bool PremapDefinitionPointers { get; internal set; }

        /// <summary>
        /// Whether all definitions would be loaded on startup
        /// </summary>
        public bool LoadAllDefinitionsOnStatup { get; internal set; }

        /// <summary>
        /// Provider that is used to fetch definitions
        /// </summary>
        public DefinitionProvider UsedProvider { get; internal set; }

        /// <summary>
        /// Definition types that are allowed to load
        /// </summary>
        public DefinitionsEnum[] AllowedDefinitions { get; internal set; }

        /// <summary>
        /// Definition types that are forbidden to load
        /// </summary>
        public DefinitionsEnum[] ForbiddenDefinitions { get; internal set; }

        /// <summary>
        /// Whether client should wait until all definitions are loaded
        /// </summary>
        public bool WaitAllDefinitionsToLoad { get; internal set; }

        /// <summary>
        /// Whether latest manifest should be downloaded on load
        /// </summary>
        public bool DownloadLatestManifestOnLoad { get; internal set; }

        /// <summary>
        /// Default settings
        /// </summary>
        public static DefinitionLoadingSettings Default => new()
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