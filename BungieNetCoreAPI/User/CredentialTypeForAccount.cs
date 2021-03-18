using Newtonsoft.Json;

namespace NetBungieAPI.User
{
    public class CredentialTypeForAccount
    {
        public BungieCredentialType CredentialType { get; }
        public string CredentialDisplayName { get; }
        public bool IsPublic { get; }
        public string CredentialAsString { get; }

        [JsonConstructor]
        internal CredentialTypeForAccount(BungieCredentialType credentialType, string credentialDisplayName, bool isPublic, string credentialAsString)
        {
            CredentialType = credentialType;
            CredentialDisplayName = CredentialDisplayName;
            IsPublic = isPublic;
            CredentialAsString = credentialAsString;
        }
    }
}
