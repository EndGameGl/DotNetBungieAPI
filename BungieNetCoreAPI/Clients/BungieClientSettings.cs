using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Clients
{
    public class BungieClientSettings
    {
        /// <summary>
        /// Whether client will save definitions or always download them again from API
        /// </summary>
        public bool UseCache { get; set; }
        /// <summary>
        /// Whether client will try to download missing definitions
        /// </summary>
        public bool TryDownloadMissingDefinitions { get; set; }
        public DestinyLocales[] Locales { get; set; }
        public string PathToLocalDb { get; set; }
    }
}
