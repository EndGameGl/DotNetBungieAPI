using NetBungieAPI.Destiny;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.Interfaces
{
    /// <summary>
    /// Interface for handling versions of the manifest
    /// </summary>
    public interface IManifestVersionHandler
    {
        DestinyManifest CurrentManifest { get; }
        /// <summary>
        /// Reads existing manifest data, if any
        /// </summary>
        Task InitiateManifestHandler();
    }
}
