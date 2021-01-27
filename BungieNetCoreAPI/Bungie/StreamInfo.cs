using Newtonsoft.Json;

namespace BungieNetCoreAPI.Bungie
{
    public class StreamInfo
    {
        public string ChannelName { get; }

        [JsonConstructor]
        internal StreamInfo(string ChannelName)
        {
            this.ChannelName = ChannelName;
        }
    }
}
