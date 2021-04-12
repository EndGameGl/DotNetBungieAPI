using System.Collections.Generic;
using System.Threading.Tasks;
using NetBungieAPI.Models.Destiny.Config;

namespace NetBungieAPI.Services.Interfaces
{
    /// <summary>
    /// Interface for handling versions of the manifest
    /// </summary>
    public interface IManifestVersionHandler
    {
        DestinyManifest CurrentUsedManifest { get; }

        ValueTask<bool> HasUpdates();
        IList<DestinyManifest> FindManifestsAt(string path);
        Task DownloadLastVersion();
        Task DownloadManifestFilesLocally(DestinyManifest manifest, string path, bool unpackSQLite, ManifestContentDownloadFilter filters);
    }
}
