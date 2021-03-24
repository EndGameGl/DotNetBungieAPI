using JsonDiffPatchDotNet;
using NetBungieAPI.Destiny;
using NetBungieAPI.Destiny.Definitions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace NetBungieAPI.DBComparer
{
    public class CompareResult
    {
        private static JsonDiffPatch _diff = new JsonDiffPatch();
        public DestinyLocales Locale { get; set; }
        public DefinitionsEnum Definition { get; set; }
        public uint Hash { get; set; }
        public string Older { get; set; }
        public string Newer { get; set; }
        public bool WasUpdated { get; set; } = false;
        public bool IsNew { get; set; } = false;

        private string debug_diff
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Older) || string.IsNullOrWhiteSpace(Newer))
                    throw new Exception("Can't compare if one value is empty.");

                var older = JToken.Parse(Older);
                var newer = JToken.Parse(Newer);

                return _diff.Diff(older, newer).ToString();
            }
        }

        public JToken Diff()
        {
            if (string.IsNullOrWhiteSpace(Older) || string.IsNullOrWhiteSpace(Newer))
                throw new Exception("Can't compare if one value is empty.");

            var older = JToken.Parse(Older);
            var newer = JToken.Parse(Newer);

            return _diff.Diff(older, newer);
        }
        public T ParseOldAs<T>()
        {
            return JsonConvert.DeserializeObject<T>(Older);
        }
        public T ParseNewAs<T>()
        {
            return JsonConvert.DeserializeObject<T>(Newer);
        }
        public DefinitionHashPointer<T> AsPointer<T>() where T : IDestinyDefinition => new DefinitionHashPointer<T>(Hash, Definition);
    }
}
