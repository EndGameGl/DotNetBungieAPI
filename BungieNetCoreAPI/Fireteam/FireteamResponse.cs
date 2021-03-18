using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Fireteam
{
    public class FireteamResponse
    {
        public FireteamSummary Summary { get; }
        public ReadOnlyCollection<FireteamMember> Members { get; }
        public ReadOnlyCollection<FireteamMember> Alternates { get; }

        [JsonConstructor]
        internal FireteamResponse(FireteamSummary Summary, FireteamMember[] Members, FireteamMember[] Alternates)
        {
            this.Summary = Summary;
            this.Members = Members.AsReadOnlyOrEmpty();
            this.Alternates = Alternates.AsReadOnlyOrEmpty();
        }
    }
}
