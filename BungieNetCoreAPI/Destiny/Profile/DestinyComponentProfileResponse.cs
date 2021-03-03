using BungieNetCoreAPI.Destiny.Profile.Components;
using BungieNetCoreAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Profile
{
    public class DestinyComponentProfileResponse
    {
        public ReadOnlyDictionary<DestinyComponentType, IProfileComponent> Components { get; }
        private ReadOnlyDictionary<long, ComponentСharacterUninstancedItems> CharacterUninstancedItemComponents { get; }

        [JsonConstructor]
        internal DestinyComponentProfileResponse(
            DestinyProfileComponent<ComponentProfileData> profile,
            DestinyProfileComponent<ComponentVendorReceiptsData> vendorReceipts,
            DestinyProfileComponent<ComponentDestinyInventory> profileInventory,
            DestinyProfileComponent<ComponentDestinyInventory> profileCurrencies,
            DestinyProfileComponent<ComponentDestinyProfileProgression> profileProgression,
            DestinyProfileComponent<ComponentDestinyPlatformSilver> platformSilver,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacter>> characters,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyInventory>> characterInventories,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacterProgression>> characterProgressions,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacterRender>> characterRenderData,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacterActivities>> characterActivities,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyInventory>> characterEquipment,
            ComponentDestinyItemSet itemComponents,
            Dictionary<long, ComponentСharacterUninstancedItems> characterUninstancedItemComponents)
        {
            var components = new Dictionary<DestinyComponentType, IProfileComponent>();

            if (profile != null)
                components.Add(DestinyComponentType.Profiles, profile);
            if (vendorReceipts != null)
                components.Add(DestinyComponentType.VendorReceipts, vendorReceipts);
            if (profileInventory != null)
                components.Add(DestinyComponentType.ProfileInventories, profileInventory);
            if (profileCurrencies != null)
                components.Add(DestinyComponentType.ProfileCurrencies, profileCurrencies);
            if (profileProgression != null)
                components.Add(DestinyComponentType.ProfileProgression, profileProgression);
            if (platformSilver != null)
                components.Add(DestinyComponentType.PlatformSilver, platformSilver);
            if (characters != null)
                components.Add(DestinyComponentType.Characters, characters);
            if (characterInventories != null)
                components.Add(DestinyComponentType.CharacterInventories, characterInventories);
            if (characterProgressions != null)
                components.Add(DestinyComponentType.CharacterProgressions, characterProgressions);
            if (characterRenderData != null)
                components.Add(DestinyComponentType.CharacterRenderData, characterRenderData);
            if (characterActivities != null)
                components.Add(DestinyComponentType.CharacterActivities, characterActivities);
            if (characterEquipment != null)
                components.Add(DestinyComponentType.CharacterEquipment, characterEquipment);
            if (itemComponents != null)
                foreach (var itemComponent in itemComponents.Components)
                    components.Add(itemComponent.Key, itemComponent.Value);
            if (characterUninstancedItemComponents != null)
                CharacterUninstancedItemComponents = characterUninstancedItemComponents.AsReadOnlyDictionaryOrEmpty();

            Components = new ReadOnlyDictionary<DestinyComponentType, IProfileComponent>(components);
        }

        private bool TryGetComponent<T>(DestinyComponentType type, out T component)
        {
            component = default;
            if (Components.TryGetValue(type, out var foundComponent))
            {
                component = ((DestinyProfileComponent<T>)foundComponent).Data;
                return true;
            }
            else
                return false;
        }
        public bool TryGetProfileData(out DestinyProfileComponent<ComponentProfileData> data)
            => TryGetComponent(DestinyComponentType.Profiles, out data);
        public bool TryGetVendorReceipts(out DestinyProfileComponent<ComponentVendorReceiptsData> data)
            => TryGetComponent(DestinyComponentType.VendorReceipts, out data);
        public bool TryGetProfileInventory(out DestinyProfileComponent<ComponentDestinyInventory> data)
            => TryGetComponent(DestinyComponentType.ProfileInventories, out data);
        public bool TryGetProfileCurrencies(out DestinyProfileComponent<ComponentDestinyInventory> data)
            => TryGetComponent(DestinyComponentType.ProfileCurrencies, out data);
        public bool TryGetProfileProgressions(out DestinyProfileComponent<ComponentDestinyProfileProgression> data)
            => TryGetComponent(DestinyComponentType.ProfileProgression, out data);
        public bool TryGetPlatformSilver(out DestinyProfileComponent<ComponentDestinyPlatformSilver> data)
            => TryGetComponent(DestinyComponentType.PlatformSilver, out data);
        public bool TryGetCharacters(out DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacter>> data)
            => TryGetComponent(DestinyComponentType.Characters, out data);
        public bool TryGetCharacterInventories(out DestinyProfileComponent<Dictionary<long, ComponentDestinyInventory>> data)
            => TryGetComponent(DestinyComponentType.CharacterInventories, out data);
        public bool TryGetCharacterProgressions(out DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacterProgression>> data)
            => TryGetComponent(DestinyComponentType.CharacterProgressions, out data);
        public bool TryGetCharacterRenderData(out DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacterRender>> data)
            => TryGetComponent(DestinyComponentType.CharacterRenderData, out data);
        public bool TryGetCharacterActivities(out DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacterActivities>> data)
            => TryGetComponent(DestinyComponentType.CharacterActivities, out data);
        public bool TryGetCharacterEquipment(out DestinyProfileComponent<Dictionary<long, ComponentDestinyInventory>> data)
            => TryGetComponent(DestinyComponentType.CharacterEquipment, out data);
        public bool TryGetItemInstances(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemInstance>> data)
            => TryGetComponent(DestinyComponentType.ItemInstances, out data);
        public bool TryGetItemObjectives(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemObjectives>> data)
            => TryGetComponent(DestinyComponentType.ItemObjectives, out data);
        public bool TryGetItemPerks(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemPerks>> data)
            => TryGetComponent(DestinyComponentType.ItemPerks, out data);
        public bool TryGetItemRenderData(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemRender>> data)
            => TryGetComponent(DestinyComponentType.ItemRenderData, out data);
        public bool TryGetItemStats(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemStats>> data)
            => TryGetComponent(DestinyComponentType.ItemStats, out data);
        public bool TryGetItemSockets(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemSockets>> data)
            => TryGetComponent(DestinyComponentType.ItemSockets, out data);
        public bool TryGetItemTalentGrids(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemTalentGrid>> data)
         => TryGetComponent(DestinyComponentType.ItemTalentGrids, out data);
        public bool TryGetItemCommonData(out ReadOnlyDictionary<long, ComponentСharacterUninstancedItems> data)
        {
            data = CharacterUninstancedItemComponents;
            return data != null;
        }
        public bool TryGetItemPlugStates(out DestinyProfileComponent<Dictionary<uint, ComponentDestinyItemPlug>> data)
         => TryGetComponent(DestinyComponentType.ItemTalentGrids, out data);
        public bool TryGetItemPlugObjectives(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemPlugObjectives>> data)
         => TryGetComponent(DestinyComponentType.ItemPlugObjectives, out data);
        public bool TryGetItemReusablePlugs(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemReusablePlugs>> data)
         => TryGetComponent(DestinyComponentType.ItemReusablePlugs, out data);
    }
}
