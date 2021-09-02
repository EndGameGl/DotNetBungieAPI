using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBungieAPI.Clients;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModifiers;
using NetBungieAPI.Models.Destiny.Definitions.ActivityTypes;
using NetBungieAPI.Models.Destiny.Definitions.Artifacts;
using NetBungieAPI.Models.Destiny.Definitions.BreakerTypes;
using NetBungieAPI.Models.Destiny.Definitions.Checklists;
using NetBungieAPI.Models.Destiny.Definitions.Classes;
using NetBungieAPI.Models.Destiny.Definitions.Collectibles;
using NetBungieAPI.Models.Destiny.Definitions.DamageTypes;
using NetBungieAPI.Models.Destiny.Definitions.Destinations;
using NetBungieAPI.Models.Destiny.Definitions.EquipmentSlots;
using NetBungieAPI.Models.Destiny.Definitions.Factions;
using NetBungieAPI.Models.Destiny.Definitions.Genders;
using NetBungieAPI.Models.Destiny.Definitions.InventoryBuckets;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.ItemCategories;
using NetBungieAPI.Models.Destiny.Definitions.ItemTierTypes;
using NetBungieAPI.Models.Destiny.Definitions.Lore;
using NetBungieAPI.Models.Destiny.Definitions.MedalTiers;
using NetBungieAPI.Models.Destiny.Definitions.Metrics;
using NetBungieAPI.Models.Destiny.Definitions.Milestones;
using NetBungieAPI.Models.Destiny.Definitions.Places;
using NetBungieAPI.Models.Destiny.Definitions.PowerCaps;
using NetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using NetBungieAPI.Models.Destiny.Definitions.Progressions;
using NetBungieAPI.Models.Destiny.Definitions.Races;
using NetBungieAPI.Models.Destiny.Definitions.Records;
using NetBungieAPI.Models.Destiny.Definitions.ReportReasonCategories;
using NetBungieAPI.Models.Destiny.Definitions.SandboxPerks;
using NetBungieAPI.Models.Destiny.Definitions.SeasonPasses;
using NetBungieAPI.Models.Destiny.Definitions.Seasons;
using NetBungieAPI.Models.Destiny.Definitions.SocketCategories;
using NetBungieAPI.Models.Destiny.Definitions.SocketTypes;
using NetBungieAPI.Models.Destiny.Definitions.Stats;
using NetBungieAPI.Models.Destiny.Definitions.TraitCategories;
using NetBungieAPI.Models.Destiny.Definitions.Traits;
using NetBungieAPI.Models.Destiny.Definitions.VendorGroups;
using NetBungieAPI.Models.Destiny.Definitions.Vendors;

namespace NetBungieAPI.HashReferencesGeneration
{
    /// <summary>
    /// Class for generating definition hash references from actual definitions
    /// </summary>
    public class DefinitionHashReferencesGenerator
    {
        private const string Namespace = "NetBungieAPI.HashReferences";
        private const string ClassName = "DefinitionHashes";

        private static readonly string[] ForbiddenSymbols =
        {
            " ", ":", "-", "\\", "/", "(", ")", "'", ".", "[", "]", "\"", "?", ",", "", "…", "!", "%", "+", "#",
            "{", "}", " ", "—", "~", "|", ";", "–", "="
        };

        private static readonly string NewLine = Environment.NewLine;
        private const char OpenCurvyBrackets = '{';
        private const char CloseCurvyBrackets = '}';
        private const char Tabulation = (char)9;

        private readonly IBungieClient _bungieClient;
        private readonly string _fileName;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="client"></param>
        /// <param name="fileName"></param>
        public DefinitionHashReferencesGenerator(IBungieClient client, string fileName = "DefinitionHashes.cs")
        {
            _bungieClient = client;
            _fileName = fileName;
        }

        /// <summary>
        /// Generates file with references
        /// </summary>
        public async Task Generate()
        {
            #region Validation and preparation

            ValidateFileExistence();
            var indentationLevel = 0;
            var stringBuilder = new StringBuilder();
            var definitionCacheLookup = new Dictionary<string, uint>();
            await using TextWriter textWriter = new StreamWriter(_fileName, true);

            #endregion

            #region namespace

            stringBuilder.Append("namespace ");
            stringBuilder.Append(Namespace);
            stringBuilder.Append(NewLine);
            stringBuilder.Append(OpenCurvyBrackets);
            stringBuilder.Append(NewLine);
            await textWriter.WriteAsync(stringBuilder.ToString());
            stringBuilder.Clear();
            indentationLevel++;

            #endregion

            #region class

            stringBuilder.Append("public static class ");
            stringBuilder.Append(ClassName);
            stringBuilder.Append(NewLine);
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, stringBuilder.ToString()));
            stringBuilder.Clear();

            // Add new line with brackets
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));
            indentationLevel++;

            #endregion

            #region Activities

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Activities")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddActivitiesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region ActivityModes

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("ActivityModes")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddActivityModesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region ActivityModifiers

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("ActivityModifiers")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddActivityModifiersInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region ActivityTypes

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("ActivityTypes")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddActivityTypesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Artifacts

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Artifacts")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddArtifactsInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region BreakerTypes

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("BreakerTypes")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddBreakerTypesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Checklists

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Checklists")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddChecklistsInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Classes

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Classes")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddClassesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Collectibles

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Collectibles")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddCollectiblesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region DamageTypes

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("DamageTypes")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddDamageTypesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Destinations

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Destinations")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddDestinationsInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region EnergyTypes

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("EnergyTypes")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddEnergyTypesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region EquipmentSlots

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("EquipmentSlots")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddEquipmentSlotsInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Factions

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Factions")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddFactionsInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Genders

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Genders")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddGendersInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region HistoricalStats

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("HistoricalStats")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddHistoricalStatsInfo(textWriter, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region InventoryBuckets

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("InventoryBuckets")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddInventoryBucketsInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region InventoryItems

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("InventoryItems")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddInventoryItemsInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region ItemCategories

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("ItemCategories")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddItemCategoriesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region ItemTierTypes

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("ItemTierTypes")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddItemTierTypesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Lore

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Lore")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddLoreInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region MedalTiers

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("MedalTiers")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddMedalTiersInfo(textWriter, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Metrics

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Metrics")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddMetricsInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Milestones

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Milestones")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddMilestonesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Places

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Places")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddPlacesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region PowerCaps

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("PowerCaps")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddPowerCapsInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region PresentationNodes

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("PresentationNodes")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddPresentationNodesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Progressions

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Progressions")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddProgressionsInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Races

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Races")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddRacesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Records

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Records")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddRecordsInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region ReportReasonCategories

            await textWriter.WriteAsync(GetIndentedString(indentationLevel,
                GetClassNameString("ReportReasonCategories")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddReportReasonCategoriesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region SandboxPerks

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("SandboxPerks")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddSandboxPerksInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Seasons

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Seasons")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddSeasonsInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region SeasonPasses

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("SeasonPasses")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddSeasonPassesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region SocketCategories

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("SocketCategories")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddSocketCategoriesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region SocketTypes

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("SocketTypes")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddSocketTypesInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Stats

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Stats")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddStatsInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region TraitCategories

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("TraitCategories")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddTraitCategoriesInfo(textWriter, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Traits

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Traits")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddTraitsInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region Vendors

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("Vendors")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddVendorsInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region VendorGroups

            await textWriter.WriteAsync(GetIndentedString(indentationLevel, GetClassNameString("VendorGroups")));
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{OpenCurvyBrackets}{NewLine}"));

            indentationLevel++;
            await AddVendorGroupsInfo(textWriter, definitionCacheLookup, indentationLevel);
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            await textWriter.FlushAsync();

            #endregion

            #region closing

            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));
            indentationLevel--;
            await textWriter.WriteAsync(GetIndentedString(indentationLevel, $"{CloseCurvyBrackets}{NewLine}"));

            #endregion
        }

        private void ValidateFileExistence()
        {
            if (File.Exists(_fileName)) File.Delete(_fileName);

            if (!File.Exists(_fileName)) File.Create(_fileName).Close();
        }

        private static string GetIndent(int level)
        {
            return new(Tabulation, level);
        }

        private static string GetIndentedString(int level, string text)
        {
            return $"{GetIndent(level)}{text}";
        }

        private static string GetClassNameString(string className)
        {
            return $"public static class {className}{NewLine}";
        }

        private static void ValidateAndAddValue(
            Dictionary<string, uint> definitionCacheLookup,
            string key,
            uint value,
            string[] forbiddenSymbols)
        {
            key ??= value.ToString();

            key = string.Join("", key.Split(forbiddenSymbols, StringSplitOptions.TrimEntries));

            if (string.IsNullOrWhiteSpace(key)) key = value.ToString();

            if (char.IsDigit(key[0])) key = $"H{key}";

            var sameEntriesAmount = definitionCacheLookup.Keys.Count(x => x.Split("_")[0] == key);

            definitionCacheLookup.Add(
                sameEntriesAmount > 0 ? $"{key}_{value}" : key, value);
        }

        private static async Task WriteCommentaryAsync(TextWriter textWriter, int indentLevel, string description)
        {
            if (!string.IsNullOrEmpty(description))
            {
                await textWriter.WriteLineAsync(GetIndentedString(indentLevel, "/// <summary>"));
                if (description.Contains("\n"))
                {
                    var lines = description.Split("\n", StringSplitOptions.RemoveEmptyEntries);
                    var arrayLength = lines.Length;
                    for (var i = 0; i < arrayLength; i++)
                    {
                        await textWriter.WriteLineAsync(GetIndentedString(
                            indentLevel,
                            $"/// {GetIndentedString(1, lines[i])}"));

                        if (i < arrayLength)
                            await textWriter.WriteLineAsync(GetIndentedString(indentLevel, "/// <para/>"));
                    }
                }
                else
                {
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentLevel,
                        $"/// {GetIndentedString(1, description)}"));
                }

                await textWriter.WriteLineAsync(GetIndentedString(indentLevel, "/// </summary>"));
            }
        }

        private async Task AddActivitiesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyActivityDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyActivityDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddActivityModesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyActivityModeDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyActivityModeDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddActivityModifiersInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyActivityModifierDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyActivityModifierDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddActivityTypesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyActivityTypeDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyActivityTypeDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddArtifactsInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyArtifactDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyArtifactDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddBreakerTypesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyBreakerTypeDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyBreakerTypeDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddChecklistsInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyChecklistDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyChecklistDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddClassesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyClassDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyClassDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddCollectiblesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyCollectibleDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyCollectibleDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddDamageTypesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyDamageTypeDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyDamageTypeDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddDestinationsInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyDestinationDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyDestinationDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddEnergyTypesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyDestinationDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyDestinationDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddEquipmentSlotsInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyEquipmentSlotDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyEquipmentSlotDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddFactionsInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyFactionDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyFactionDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddGendersInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyGenderDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyGenderDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddHistoricalStatsInfo(
            TextWriter textWriter,
            int indentationLevel)
        {
            foreach (var statsDefinition in _bungieClient.Repository.GetAllHistoricalStatsDefinitions(BungieLocales.EN))
            {
                var key = char.ToUpper(statsDefinition.StatId.First()) + statsDefinition.StatId[1..];
                if (key.Contains('_'))
                {
                    var split = key.Split('_');
                    key = string.Empty;
                    for (var index = 0; index < split.Length; index++)
                    {
                        var entry = split[index];
                        key += char.ToUpper(entry.First()) + entry[1..];
                    }
                }

                await WriteCommentaryAsync(textWriter, indentationLevel, statsDefinition.StatDescription);

                await textWriter.WriteLineAsync(GetIndentedString(
                    indentationLevel,
                    $"public const string {key} = \"{statsDefinition.StatId}\";"));
            }
        }

        private async Task AddInventoryBucketsInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyInventoryBucketDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyInventoryBucketDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddInventoryItemsInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyInventoryItemDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyInventoryItemDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddItemCategoriesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyItemCategoryDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyItemCategoryDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddItemTierTypesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyItemTierTypeDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyItemTierTypeDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddLoreInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyLoreDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyLoreDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddMedalTiersInfo(
            TextWriter textWriter,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyMedalTierDefinition>())
                await textWriter.WriteLineAsync(GetIndentedString(
                    indentationLevel,
                    $"public const uint {definition.TierName.Replace(" ", "")} = {definition.Hash};"));
        }

        private async Task AddMilestonesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyMetricDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyMetricDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddMetricsInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyMilestoneDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyMilestoneDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddPlacesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyPlaceDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyPlaceDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddPowerCapsInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyPowerCapDefinition>())
                ValidateAndAddValue(
                    definitionCacheLookup,
                    definition.PowerCap.ToString(),
                    definition.Hash,
                    ForbiddenSymbols);

            foreach (var (key, value) in definitionCacheLookup)
                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));

            definitionCacheLookup.Clear();
        }

        private async Task AddPresentationNodesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyPresentationNodeDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyPresentationNodeDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddProgressionsInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyProgressionDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyProgressionDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddRacesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyRaceDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyRaceDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddRecordsInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyRecordDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyRecordDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddReportReasonCategoriesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyReportReasonCategoryDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyReportReasonCategoryDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddSandboxPerksInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinySandboxPerkDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinySandboxPerkDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddSeasonsInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinySeasonDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinySeasonDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddSeasonPassesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinySeasonPassDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinySeasonPassDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddSocketCategoriesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinySocketCategoryDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinySocketCategoryDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddSocketTypesInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinySocketTypeDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinySocketTypeDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddStatsInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyStatDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyStatDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddTraitCategoriesInfo(
            TextWriter textWriter,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyTraitCategoryDefinition>())
            {
                var key = char.ToUpper(definition.TraitCategoryId.First()) + definition.TraitCategoryId[1..];
                if (key.Contains('_'))
                {
                    var split = key.Split('_');
                    key = string.Empty;
                    for (var index = 0; index < split.Length; index++)
                    {
                        var entry = split[index];
                        key += char.ToUpper(entry.First()) + entry[1..];
                    }
                }

                await textWriter.WriteLineAsync(GetIndentedString(
                    indentationLevel,
                    $"public const uint {key} = {definition.Hash};"));
            }
        }

        private async Task AddTraitsInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyTraitDefinition>())
                if (definition.DisplayProperties is not null)
                {
                    if (!string.IsNullOrEmpty(definition.DisplayProperties.Name))
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            ForbiddenSymbols);
                    }
                    else if (definition.TraitCategory.TryGetDefinition(out var traitCategoryDefinition))
                    {
                        var pointer = traitCategoryDefinition.Traits.First(x => x.Hash == definition.Hash);
                        var index = traitCategoryDefinition.Traits.IndexOf(pointer);
                        var name = traitCategoryDefinition.TraitIds[index];

                        name = char.ToUpper(name.First()) + name[1..];

                        if (name.Contains('_'))
                        {
                            var split = name.Split('_');
                            name = string.Empty;
                            for (var i = 0; i < split.Length; i++)
                            {
                                var entry = split[i];
                                name += char.ToUpper(entry.First()) + entry[1..];
                            }
                        }

                        if (name.Contains('.'))
                        {
                            var split = name.Split('.');
                            name = string.Empty;
                            for (var i = 0; i < split.Length; i++)
                            {
                                var entry = split[i];
                                name += char.ToUpper(entry.First()) + entry[1..];
                            }
                        }

                        ValidateAndAddValue(
                            definitionCacheLookup,
                            name,
                            definition.Hash,
                            ForbiddenSymbols);
                    }
                }
                else
                {
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);
                }

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyTraitDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddVendorsInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyVendorDefinition>())
                if (definition.DisplayProperties is not null)
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash,
                        ForbiddenSymbols);
                else
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyVendorDefinition>(
                    value, BungieLocales.EN, out var definition))
                    await WriteCommentaryAsync(textWriter, indentationLevel, definition.DisplayProperties?.Description);

                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));
            }

            definitionCacheLookup.Clear();
        }

        private async Task AddVendorGroupsInfo(
            TextWriter textWriter,
            Dictionary<string, uint> definitionCacheLookup,
            int indentationLevel)
        {
            foreach (var definition in _bungieClient.Repository.GetAll<DestinyVendorGroupDefinition>())
                ValidateAndAddValue(
                    definitionCacheLookup,
                    definition.CategoryName,
                    definition.Hash,
                    ForbiddenSymbols);

            foreach (var (key, value) in definitionCacheLookup)
                if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                    !key.Contains(value.ToString()))
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key}_{value} = {value};"));
                else
                    await textWriter.WriteLineAsync(GetIndentedString(
                        indentationLevel,
                        $"public const uint {key} = {value};"));

            definitionCacheLookup.Clear();
        }
    }
}