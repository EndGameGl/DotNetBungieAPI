using Newtonsoft.Json;

namespace NetBungieAPI.User
{
    public class UserTheme
    {
        public int UserThemeId { get; }
        public string UserThemeName { get; }
        public string UserThemeDescription { get; }

        [JsonConstructor]
        internal UserTheme(int userThemeId, string userThemeName, string userThemeDescription)
        {
            UserThemeId = userThemeId;
            UserThemeName = userThemeName;
            UserThemeDescription = userThemeDescription;
        }
    }
}
