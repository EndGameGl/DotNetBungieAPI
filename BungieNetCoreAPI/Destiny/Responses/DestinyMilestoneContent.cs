using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Responses
{
    public class DestinyMilestoneContent
    {
        public string About { get; }
        public string Status { get; }
        public ReadOnlyCollection<string> Tips { get; }
        public ReadOnlyCollection<DestinyMilestoneContentItemCategory> ItemCategories { get; }

        [JsonConstructor]
        internal DestinyMilestoneContent(string about, string status, string[] tips, DestinyMilestoneContentItemCategory[] itemCategories)
        {
            About = about;
            Status = status;
            Tips = tips.AsReadOnlyOrEmpty();
            ItemCategories = itemCategories.AsReadOnlyOrEmpty();
        }
    }
}
