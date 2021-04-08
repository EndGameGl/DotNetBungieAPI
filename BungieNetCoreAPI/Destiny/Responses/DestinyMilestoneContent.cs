using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NetBungieAPI.Destiny.Responses
{
    public class DestinyMilestoneContent
    {
        public string About { get; init; }
        public string Status { get; init; }
        public ReadOnlyCollection<string> Tips { get; init; }
        public ReadOnlyCollection<DestinyMilestoneContentItemCategory> ItemCategories { get; init; }

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
