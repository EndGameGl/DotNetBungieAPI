using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentVendorReceiptsData
    {
        public List<object> Receipts { get; }
        [JsonConstructor]
        private ComponentVendorReceiptsData(List<object> receipts)
        {
            Receipts = receipts;
        }
    }
}
