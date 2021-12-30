using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     An enumeration of the known UI interactions for Vendors.
/// </summary>
public enum VendorInteractionType : int
{
    Unknown = 0,
    /// <summary>
    ///     An empty interaction. If this ends up in content, it is probably a game bug.
    /// </summary>
    Undefined = 1,
    /// <summary>
    ///     An interaction shown when you complete a quest and receive a reward.
    /// </summary>
    QuestComplete = 2,
    /// <summary>
    ///     An interaction shown when you talk to a Vendor as an intermediary step of a quest.
    /// </summary>
    QuestContinue = 3,
    /// <summary>
    ///     An interaction shown when you are previewing the vendor's reputation rewards.
    /// </summary>
    ReputationPreview = 4,
    /// <summary>
    ///     An interaction shown when you rank up with the vendor.
    /// </summary>
    RankUpReward = 5,
    /// <summary>
    ///     An interaction shown when you have tokens to turn in for the vendor.
    /// </summary>
    TokenTurnIn = 6,
    /// <summary>
    ///     An interaction shown when you're accepting a new quest.
    /// </summary>
    QuestAccept = 7,
    /// <summary>
    ///     Honestly, this doesn't seem consistent to me. It is used to give you choices in the Cryptarch as well as some reward prompts by the Eververse vendor. I'll have to look into that further at some point.
    /// </summary>
    ProgressTab = 8,
    /// <summary>
    ///     These seem even less consistent. I don't know what these are.
    /// </summary>
    End = 9,
    /// <summary>
    ///     Also seem inconsistent. I also don't know what these are offhand.
    /// </summary>
    Start = 10
}
