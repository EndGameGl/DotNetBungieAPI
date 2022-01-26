namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     This defines the properties of a "Talent Node Step". When you see a talent node in game, the actual visible properties that you see (its icon, description, the perks and stats it provides) are not provided by the Node itself, but rather by the currently active Step on the node.
/// <para />
///     When a Talent Node is activated, the currently active step's benefits are conferred upon the item and character.
/// <para />
///     The currently active step on talent nodes are determined when an item is first instantiated. Sometimes it is random, sometimes it is more deterministic (particularly when a node has only a single step).
/// <para />
///     Note that, when dealing with Talent Node Steps, you must ensure that you have the latest version of content. stepIndex and nodeStepHash - two ways of identifying the step within a node - are both content version dependent, and thus are subject to change between content updates.
/// </summary>
public class DestinyNodeStepDefinition : IDeepEquatable<DestinyNodeStepDefinition>
{
    /// <summary>
    ///     These are the display properties actually used to render the Talent Node. The currently active step's displayProperties are shown.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     The index of this step in the list of Steps on the Talent Node.
    /// <para />
    ///     Unfortunately, this is the closest thing we have to an identifier for the Step: steps are not provided a content version agnostic identifier. This means that, when you are dealing with talent nodes, you will need to first ensure that you have the latest version of content.
    /// </summary>
    [JsonPropertyName("stepIndex")]
    public int StepIndex { get; set; }

    /// <summary>
    ///     The hash of this node step. Unfortunately, while it can be used to uniquely identify the step within a node, it is also content version dependent and should not be relied on without ensuring you have the latest vesion of content.
    /// </summary>
    [JsonPropertyName("nodeStepHash")]
    public uint NodeStepHash { get; set; }

    /// <summary>
    ///     If you can interact with this node in some way, this is the localized description of that interaction.
    /// </summary>
    [JsonPropertyName("interactionDescription")]
    public string InteractionDescription { get; set; }

    /// <summary>
    ///     An enum representing a damage type granted by activating this step, if any.
    /// </summary>
    [JsonPropertyName("damageType")]
    public Destiny.DamageType DamageType { get; set; }

    /// <summary>
    ///     If the step provides a damage type, this will be the hash identifier used to look up the damage type's DestinyDamageTypeDefinition.
    /// </summary>
    [JsonPropertyName("damageTypeHash")]
    public uint? DamageTypeHash { get; set; }

    /// <summary>
    ///     If the step has requirements for activation (they almost always do, if nothing else than for the Talent Grid's Progression to have reached a certain level), they will be defined here.
    /// </summary>
    [JsonPropertyName("activationRequirement")]
    public Destiny.Definitions.DestinyNodeActivationRequirement ActivationRequirement { get; set; }

    /// <summary>
    ///     There was a time when talent nodes could be activated multiple times, and the effects of subsequent Steps would be compounded on each other, essentially "upgrading" the node. We have moved away from this, but theoretically the capability still exists.
    /// <para />
    ///     I continue to return this in case it is used in the future: if true and this step is the current step in the node, you are allowed to activate the node a second time to receive the benefits of the next step in the node, which will then become the active step.
    /// </summary>
    [JsonPropertyName("canActivateNextStep")]
    public bool CanActivateNextStep { get; set; }

    /// <summary>
    ///     The stepIndex of the next step in the talent node, or -1 if this is the last step or if the next step to be chosen is random.
    /// <para />
    ///     This doesn't really matter anymore unless canActivateNextStep begins to be used again.
    /// </summary>
    [JsonPropertyName("nextStepIndex")]
    public int NextStepIndex { get; set; }

    /// <summary>
    ///     If true, the next step to be chosen is random, and if you're allowed to activate the next step. (if canActivateNextStep = true)
    /// </summary>
    [JsonPropertyName("isNextStepRandom")]
    public bool IsNextStepRandom { get; set; }

    /// <summary>
    ///     The list of hash identifiers for Perks (DestinySandboxPerkDefinition) that are applied when this step is active. Perks provide a variety of benefits and modifications - examine DestinySandboxPerkDefinition to learn more.
    /// </summary>
    [JsonPropertyName("perkHashes")]
    public List<uint> PerkHashes { get; set; }

    /// <summary>
    ///     When the Talent Grid's progression reaches this value, the circular "progress bar" that surrounds the talent node should be shown.
    /// <para />
    ///     This also indicates the lower bound of said progress bar, with the upper bound being the progress required to reach activationRequirement.gridLevel. (at some point I should precalculate the upper bound and put it in the definition to save people time)
    /// </summary>
    [JsonPropertyName("startProgressionBarAtProgress")]
    public int StartProgressionBarAtProgress { get; set; }

    /// <summary>
    ///     When the step provides stat benefits on the item or character, this is the list of hash identifiers for stats (DestinyStatDefinition) that are provided.
    /// </summary>
    [JsonPropertyName("statHashes")]
    public List<uint> StatHashes { get; set; }

    /// <summary>
    ///     If this is true, the step affects the item's Quality in some way. See DestinyInventoryItemDefinition for more information about the meaning of Quality. I already made a joke about Zen and the Art of Motorcycle Maintenance elsewhere in the documentation, so I will avoid doing it again. Oops too late
    /// </summary>
    [JsonPropertyName("affectsQuality")]
    public bool AffectsQuality { get; set; }

    /// <summary>
    ///     In Destiny 1, the Armory's Perk Filtering was driven by a concept of TalentNodeStepGroups: categorizations of talent nodes based on their functionality. While the Armory isn't a BNet-facing thing for now, and the new Armory will need to account for Sockets rather than Talent Nodes, this categorization capability feels useful enough to still keep around.
    /// </summary>
    [JsonPropertyName("stepGroups")]
    public Destiny.Definitions.DestinyTalentNodeStepGroups StepGroups { get; set; }

    /// <summary>
    ///     If true, this step can affect the level of the item. See DestinyInventoryItemDefintion for more information about item levels and their effect on stats.
    /// </summary>
    [JsonPropertyName("affectsLevel")]
    public bool AffectsLevel { get; set; }

    /// <summary>
    ///     If this step is activated, this will be a list of information used to replace socket items with new Plugs. See DestinyInventoryItemDefinition for more information about sockets and plugs.
    /// </summary>
    [JsonPropertyName("socketReplacements")]
    public List<Destiny.Definitions.DestinyNodeSocketReplaceResponse> SocketReplacements { get; set; }

    public bool DeepEquals(DestinyNodeStepDefinition? other)
    {
        return other is not null &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               StepIndex == other.StepIndex &&
               NodeStepHash == other.NodeStepHash &&
               InteractionDescription == other.InteractionDescription &&
               DamageType == other.DamageType &&
               DamageTypeHash == other.DamageTypeHash &&
               (ActivationRequirement is not null ? ActivationRequirement.DeepEquals(other.ActivationRequirement) : other.ActivationRequirement is null) &&
               CanActivateNextStep == other.CanActivateNextStep &&
               NextStepIndex == other.NextStepIndex &&
               IsNextStepRandom == other.IsNextStepRandom &&
               PerkHashes.DeepEqualsListNaive(other.PerkHashes) &&
               StartProgressionBarAtProgress == other.StartProgressionBarAtProgress &&
               StatHashes.DeepEqualsListNaive(other.StatHashes) &&
               AffectsQuality == other.AffectsQuality &&
               (StepGroups is not null ? StepGroups.DeepEquals(other.StepGroups) : other.StepGroups is null) &&
               AffectsLevel == other.AffectsLevel &&
               SocketReplacements.DeepEqualsList(other.SocketReplacements);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyNodeStepDefinition? other)
    {
        if (other is null) return;
        if (!DisplayProperties.DeepEquals(other.DisplayProperties))
        {
            DisplayProperties.Update(other.DisplayProperties);
            OnPropertyChanged(nameof(DisplayProperties));
        }
        if (StepIndex != other.StepIndex)
        {
            StepIndex = other.StepIndex;
            OnPropertyChanged(nameof(StepIndex));
        }
        if (NodeStepHash != other.NodeStepHash)
        {
            NodeStepHash = other.NodeStepHash;
            OnPropertyChanged(nameof(NodeStepHash));
        }
        if (InteractionDescription != other.InteractionDescription)
        {
            InteractionDescription = other.InteractionDescription;
            OnPropertyChanged(nameof(InteractionDescription));
        }
        if (DamageType != other.DamageType)
        {
            DamageType = other.DamageType;
            OnPropertyChanged(nameof(DamageType));
        }
        if (DamageTypeHash != other.DamageTypeHash)
        {
            DamageTypeHash = other.DamageTypeHash;
            OnPropertyChanged(nameof(DamageTypeHash));
        }
        if (!ActivationRequirement.DeepEquals(other.ActivationRequirement))
        {
            ActivationRequirement.Update(other.ActivationRequirement);
            OnPropertyChanged(nameof(ActivationRequirement));
        }
        if (CanActivateNextStep != other.CanActivateNextStep)
        {
            CanActivateNextStep = other.CanActivateNextStep;
            OnPropertyChanged(nameof(CanActivateNextStep));
        }
        if (NextStepIndex != other.NextStepIndex)
        {
            NextStepIndex = other.NextStepIndex;
            OnPropertyChanged(nameof(NextStepIndex));
        }
        if (IsNextStepRandom != other.IsNextStepRandom)
        {
            IsNextStepRandom = other.IsNextStepRandom;
            OnPropertyChanged(nameof(IsNextStepRandom));
        }
        if (!PerkHashes.DeepEqualsListNaive(other.PerkHashes))
        {
            PerkHashes = other.PerkHashes;
            OnPropertyChanged(nameof(PerkHashes));
        }
        if (StartProgressionBarAtProgress != other.StartProgressionBarAtProgress)
        {
            StartProgressionBarAtProgress = other.StartProgressionBarAtProgress;
            OnPropertyChanged(nameof(StartProgressionBarAtProgress));
        }
        if (!StatHashes.DeepEqualsListNaive(other.StatHashes))
        {
            StatHashes = other.StatHashes;
            OnPropertyChanged(nameof(StatHashes));
        }
        if (AffectsQuality != other.AffectsQuality)
        {
            AffectsQuality = other.AffectsQuality;
            OnPropertyChanged(nameof(AffectsQuality));
        }
        if (!StepGroups.DeepEquals(other.StepGroups))
        {
            StepGroups.Update(other.StepGroups);
            OnPropertyChanged(nameof(StepGroups));
        }
        if (AffectsLevel != other.AffectsLevel)
        {
            AffectsLevel = other.AffectsLevel;
            OnPropertyChanged(nameof(AffectsLevel));
        }
        if (!SocketReplacements.DeepEqualsList(other.SocketReplacements))
        {
            SocketReplacements = other.SocketReplacements;
            OnPropertyChanged(nameof(SocketReplacements));
        }
    }
}