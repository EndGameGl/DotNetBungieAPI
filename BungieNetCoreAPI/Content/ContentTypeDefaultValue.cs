using Newtonsoft.Json;

namespace NetBungieAPI.Content
{
    public class ContentTypeDefaultValue
    {
        public string WhenClause { get; }
        public string WhenValue { get; }
        public string DefaultValue { get; }

        [JsonConstructor]
        internal ContentTypeDefaultValue(string whenClause, string whenValue, string defaultValue)
        {
            WhenClause = whenClause;
            WhenValue = whenValue;
            DefaultValue = defaultValue;
        }
    }
}
