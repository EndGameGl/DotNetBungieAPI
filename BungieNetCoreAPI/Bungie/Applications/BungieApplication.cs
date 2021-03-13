using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace NetBungieApi.Bungie.Applications
{
    public class BungieApplication
    {
        public int ApplicationId { get; }
        public string Name { get; }
        public string RedirectUrl { get; }
        public string Link { get; }
        public string Scope { get; }
        public string Origin { get; }
        public int Status { get; }
        public DateTime CreationDate { get; }
        public DateTime StatusChanged { get; }
        public DateTime FirstPublished { get; }
        public ReadOnlyCollection<BungieApplicationDeveloper> Team { get; }

        [JsonConstructor]
        internal BungieApplication(int applicationId, string name, string redirectUrl, string link, string scope, string origin, int status, DateTime creationDate,
            DateTime statusChanged, DateTime firstPublished, BungieApplicationDeveloper[] team)
        {
            ApplicationId = applicationId;
            Name = name;
            RedirectUrl = redirectUrl;
            Link = link;
            Scope = scope;
            Origin = origin;
            Status = status;
            CreationDate = creationDate;
            StatusChanged = statusChanged;
            FirstPublished = firstPublished;
            Team = team.AsReadOnlyOrEmpty();
        }
    }
}
