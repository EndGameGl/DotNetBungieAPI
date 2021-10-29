using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.Destiny.Definitions;

namespace DotNetBungieAPI.Models.Destiny.TalentNodes
{
    /// <summary>
    ///     I see you've come to find out more about Talent Nodes. I'm so sorry. Talent Nodes are the conceptual, visual nodes
    ///     that appear on Talent Grids. Talent Grids, in Destiny 1, were found on almost every instanced item: they had Nodes
    ///     that could be activated to change the properties of the item. In Destiny 2, Talent Grids only exist for
    ///     Builds/Subclasses, and while the basic concept is the same (Nodes can be activated once you've gained sufficient
    ///     Experience on the Item, and provide effects), there are some new concepts from Destiny 1. Examine
    ///     DestinyTalentGridDefinition and its subordinates for more information. This is the "Live" information for the
    ///     current status of a Talent Node on a specific item. Talent Nodes have many Steps, but only one can be active at any
    ///     one time: and it is the Step that determines both the visual and the game state-changing properties that the Node
    ///     provides. Examine this and DestinyTalentNodeStepDefinition carefully. *IMPORTANT NOTE* Talent Nodes are,
    ///     unfortunately, Content Version DEPENDENT. Though they refer to hashes for Nodes and Steps, those hashes are not
    ///     guaranteed to be immutable across content versions. This is a source of great exasperation for me, but as a result
    ///     anyone using Talent Grid data must ensure that the content version of their static content matches that of the
    ///     server responses before showing or making decisions based on talent grid data.
    /// </summary>
    public sealed record DestinyTalentNode
    {
        /// <summary>
        ///     The index of the Talent Node being referred to (an index into DestinyTalentGridDefinition.nodes[]). CONTENT VERSION
        ///     DEPENDENT.
        /// </summary>
        [JsonPropertyName("nodeIndex")]
        public int NodeIndex { get; init; }

        /// <summary>
        ///     The hash of the Talent Node being referred to (in DestinyTalentGridDefinition.nodes). Deceptively CONTENT VERSION
        ///     DEPENDENT. We have no guarantee of the hash's immutability between content versions.
        /// </summary>
        [JsonPropertyName("nodeHash")]
        public uint NodeHash { get; init; }

        /// <summary>
        ///     An DestinyTalentNodeState enum value indicating the node's state: whether it can be activated or swapped, and why
        ///     not if neither can be performed.
        /// </summary>
        [JsonPropertyName("state")]
        public DestinyTalentNodeState State { get; init; }

        /// <summary>
        ///     If true, the node is activated: it's current step then provides its benefits.
        /// </summary>
        [JsonPropertyName("isActivated")]
        public bool IsActivated { get; init; }

        /// <summary>
        ///     The currently relevant Step for the node. It is this step that has rendering data for the node and the benefits
        ///     that are provided if the node is activated. (the actual rules for benefits provided are extremely complicated in
        ///     theory, but with how Talent Grids are being used in Destiny 2 you don't have to worry about a lot of those old
        ///     Destiny 1 rules.) This is an index into: DestinyTalentGridDefinition.nodes[nodeIndex].steps[stepIndex]
        /// </summary>
        [JsonPropertyName("stepIndex")]
        public int StepIndex { get; init; }

        /// <summary>
        ///     If the node has material requirements to be activated, this is the list of those requirements.
        /// </summary>
        [JsonPropertyName("materialsToUpgrade")]
        public ReadOnlyCollection<DestinyMaterialRequirement> MaterialsToUpgrade { get; init; } =
            ReadOnlyCollections<DestinyMaterialRequirement>.Empty;

        /// <summary>
        ///     The progression level required on the Talent Grid in order to be able to activate this talent node. Talent Grids
        ///     have their own Progression - similar to Character Level, but in this case it is experience related to the item
        ///     itself.
        /// </summary>
        [JsonPropertyName("activationGridLevel")]
        public int ActivationGridLevel { get; init; }

        /// <summary>
        ///     If you want to show a progress bar or circle for how close this talent node is to being activate-able, this is the
        ///     percentage to show. It follows the node's underlying rules about when the progress bar should first show up, and
        ///     when it should be filled.
        /// </summary>
        [JsonPropertyName("progressPercent")]
        public float ProgressPercent { get; init; }

        /// <summary>
        ///     Whether or not the talent node is actually visible in the game's UI. Whether you want to show it in your own UI is
        ///     up to you! I'm not gonna tell you who to sock it to.
        /// </summary>
        [JsonPropertyName("hidden")]
        public bool IsHidden { get; init; }

        /// <summary>
        ///     This property has some history. A talent grid can provide stats on both the item it's related to and the character
        ///     equipping the item. This returns data about those stat bonuses.
        /// </summary>
        [JsonPropertyName("nodeStatsBlock")]
        public DestinyTalentNodeStatBlock NodeStatsBlock { get; init; }
    }
}