using System;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny
{
    /// <summary>
    ///     A Flags Enumeration/bitmask where each bit represents a different state that the Collectible can be in. A
    ///     collectible can be in any number of these states, and you can choose to use or ignore any or all of them when
    ///     making your own UI that shows Collectible info. Our displays are going to honor them, but we're also the kind of
    ///     people who only pretend to inhale before quickly passing it to the left. So, you know, do what you got to do.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DestinyCollectibleState
    {
        None = 0,

        /// <summary>
        ///     If this flag is set, you have not yet obtained this collectible.
        /// </summary>
        NotAcquired = 1,

        /// <summary>
        ///     If this flag is set, the item is "obscured" to you: you can/should use the alternate item hash found in
        ///     DestinyCollectibleDefinition.stateInfo.obscuredOverrideItemHash when displaying this collectible instead of the
        ///     default display info.
        /// </summary>
        Obscured = 2,

        /// <summary>
        ///     If this flag is set, the collectible should not be shown to the user.
        ///     <para />
        ///     Please do consider honoring this flag. It is used - for example - to hide items that a person didn't get from the
        ///     Eververse. I can't prevent these from being returned in definitions, because some people may have acquired them and
        ///     thus they should show up: but I would hate for people to start feeling some variant of a Collector's Remorse about
        ///     these items, and thus increasing their purchasing based on that compulsion. That would be a very unfortunate
        ///     outcome, and one that I wouldn't like to see happen. So please, whether or not I'm your mom, consider honoring this
        ///     flag and don't show people invisible collectibles.
        /// </summary>
        Invisible = 4,

        /// <summary>
        ///     If this flag is set, the collectible requires payment for creating an instance of the item, and you are lacking in
        ///     currency. Bring the benjamins next time. Or spinmetal. Whatever.
        /// </summary>
        CannotAffordMaterialRequirements = 8,

        /// <summary>
        ///     If this flag is set, you can't pull this item out of your collection because there's no room left in your
        ///     inventory.
        /// </summary>
        InventorySpaceUnavailable = 16,

        /// <summary>
        ///     If this flag is set, you already have one of these items and can't have a second one.
        /// </summary>
        UniquenessViolation = 32,

        /// <summary>
        ///     If this flag is set, the ability to pull this item out of your collection has been disabled.
        /// </summary>
        PurchaseDisabled = 64
    }
}