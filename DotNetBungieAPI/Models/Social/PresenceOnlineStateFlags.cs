namespace DotNetBungieAPI.Models.Social;

[Flags]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PresenceOnlineStateFlags
{
    None = 0,
    Destiny1 = 1,
    Destiny2 = 2
}