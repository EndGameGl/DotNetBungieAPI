namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Profiles;

/// <summary>
///     This is some bare minimum information about a party member in a Fireteam. Unfortunately, without great computational expense on our side we can only get at the data contained here. I'd like to give you a character ID for example, but we don't have it. But we do have these three pieces of information. May they help you on your quest to show meaningful data about current Fireteams.
/// <para />
///     Notably, we don't and can't feasibly return info on characters. If you can, try to use just the data below for your UI and purposes. Only hit us with further queries if you absolutely must know the character ID of the currently playing character. Pretty please with sugar on top.
/// </summary>
public sealed class DestinyProfileTransitoryPartyMember
{

    /// <summary>
    ///     The Membership ID that matches the party member.
    /// </summary>
    [JsonPropertyName("membershipId")]
    public long MembershipId { get; init; }

    /// <summary>
    ///     The identifier for the DestinyInventoryItemDefinition of the player's emblem.
    /// </summary>
    [JsonPropertyName("emblemHash")]
    public uint EmblemHash { get; init; } // DestinyInventoryItemDefinition

    /// <summary>
    ///     The player's last known display name.
    /// </summary>
    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; }

    /// <summary>
    ///     A Flags Enumeration value indicating the states that the player is in relevant to being on a fireteam.
    /// </summary>
    [JsonPropertyName("status")]
    public Destiny.DestinyPartyMemberStates Status { get; init; }
}
