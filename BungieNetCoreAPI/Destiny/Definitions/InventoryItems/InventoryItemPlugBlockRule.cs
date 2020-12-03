using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemPlugBlockRule
    {
        public string FailureMessage { get; }

        [JsonConstructor]
        private InventoryItemPlugBlockRule(string failureMessage)
        {
            FailureMessage = failureMessage;
        }
    }
}
