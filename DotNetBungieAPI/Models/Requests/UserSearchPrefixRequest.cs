namespace DotNetBungieAPI.Models.Requests
{
    public class UserSearchPrefixRequest
    {
        [JsonPropertyName("displayNamePrefix")]
        public string DisplayNamePrefix { get; }

        public UserSearchPrefixRequest(string displayNamePrefix)
        {
            DisplayNamePrefix = Conditions.NotNullOrWhiteSpace(displayNamePrefix);
        }
    }
}
