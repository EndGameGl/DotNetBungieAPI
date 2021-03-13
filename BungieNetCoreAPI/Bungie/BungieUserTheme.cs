using Newtonsoft.Json;

namespace NetBungieApi.Bungie
{
    public class BungieUserTheme
    {
        public int UserThemeId { get; }
        public string UserThemeName { get; }
        public string UserThemeDescription { get; }

        [JsonConstructor]
        internal BungieUserTheme(int userThemeId, string userThemeName, string userThemeDescription)
        {
            UserThemeId = userThemeId;
            UserThemeName = userThemeName;
            UserThemeDescription = userThemeDescription;
        }
    }
}
