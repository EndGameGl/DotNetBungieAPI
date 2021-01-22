﻿using System.Threading.Tasks;

namespace BungieNetCoreAPI.Services
{
    /// <summary>
    /// Interface for handling versions of the manifest
    /// </summary>
    public interface IManifestUpdateHandler
    {
        /// <summary>
        /// Reads existing manifest data, if any
        /// </summary>
        Task InitiateManifestHandler();
        /// <summary>
        /// Checks latest manifest data
        /// </summary>
        Task UpdateManifestData();
        /// <summary>
        /// Loads data from disk
        /// </summary>
        /// <returns></returns>
        Task LoadData();
    }
}
