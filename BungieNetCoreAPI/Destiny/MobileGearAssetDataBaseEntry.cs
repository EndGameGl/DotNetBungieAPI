using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny
{
    public class MobileGearAssetDataBaseEntry
    {
        public int Version { get; }
        public string Path { get; }

        [JsonConstructor]
        private MobileGearAssetDataBaseEntry(int version, string path)
        {
            Version = version;
            Path = path;
        }
    }
}
