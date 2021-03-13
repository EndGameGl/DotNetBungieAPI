using Newtonsoft.Json;

namespace NetBungieApi.Bungie
{
    public class BungieNetUserAccountCredentialType
    {
        public BungieCredentialType CredentialType { get; }
        public string CredentialDisplayName { get; }
        public bool IsPublic { get; }
        public string CredentialAsString { get; }

        [JsonConstructor]
        internal BungieNetUserAccountCredentialType(BungieCredentialType credentialType, string credentialDisplayName, bool isPublic, string credentialAsString)
        {
            CredentialType = credentialType;
            CredentialDisplayName = credentialDisplayName;
            IsPublic = isPublic;
            CredentialAsString = credentialAsString;
        }
    }
}
