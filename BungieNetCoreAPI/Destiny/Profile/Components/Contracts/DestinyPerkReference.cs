﻿using NetBungieAPI.Destiny.Definitions.SandboxPerks;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPerkReference
    {
        public DefinitionHashPointer<DestinySandboxPerkDefinition> Perk { get; }
        public string IconPath { get; }
        public bool IsActive { get; }
        public bool IsVisible { get; }

        [JsonConstructor]
        internal DestinyPerkReference(uint perkHash, string iconPath, bool isActive, bool visible)
        {
            Perk = new DefinitionHashPointer<DestinySandboxPerkDefinition>(perkHash, DefinitionsEnum.DestinySandboxPerkDefinition);
            IconPath = iconPath;
            IsActive = isActive;
            IsVisible = visible;
        }
    }
}
