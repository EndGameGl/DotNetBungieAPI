using Newtonsoft.Json;

namespace NetBungieAPI.Bungie
{
    public class EmailSettingSubscriptionLocalization
    {
        public string UnknownUserDescription { get; }
        public string RegisteredUserDescription { get; }
        public string UnregisteredUserDescription { get; }
        public string UnknownUserActionText { get; }
        public string KnownUserActionText { get; }
        public string Title { get; }
        public string Description { get; }

        [JsonConstructor]
        internal EmailSettingSubscriptionLocalization(string unknownUserDescription, string registeredUserDescription, string unregisteredUserDescription,
            string unknownUserActionText, string knownUserActionText, string title, string description)
        {
            UnknownUserDescription = unknownUserDescription;
            RegisteredUserDescription = registeredUserDescription;
            UnregisteredUserDescription = unregisteredUserDescription;
            UnknownUserActionText = unknownUserActionText;
            KnownUserActionText = knownUserActionText;
            Title = title;
            Description = description;
        }
    }
}
