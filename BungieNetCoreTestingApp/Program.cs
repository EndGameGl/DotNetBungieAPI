using NetBungieAPI.Models.Applications;
using NetBungieAPI.Attributes;
using NetBungieAPI.Clients;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Models.Trending;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Providers;
using NetBungieAPI.Serialization;
using System.Linq;

namespace NetBungieAPI.TestProject
{
    class Program
    {
        private static DestinyComponentType[] ALL_COMPONENTS_ARRAY = new DestinyComponentType[]
        {
            DestinyComponentType.Profiles,
            DestinyComponentType.VendorReceipts,
            DestinyComponentType.ProfileInventories,
            DestinyComponentType.ProfileCurrencies,
            DestinyComponentType.ProfileProgression,
            DestinyComponentType.PlatformSilver,

            DestinyComponentType.Characters,
            DestinyComponentType.CharacterInventories,
            DestinyComponentType.CharacterProgressions,
            DestinyComponentType.CharacterRenderData,
            DestinyComponentType.CharacterActivities,
            DestinyComponentType.CharacterEquipment,

            DestinyComponentType.ItemInstances,
            DestinyComponentType.ItemObjectives,
            DestinyComponentType.ItemPerks,
            DestinyComponentType.ItemRenderData,
            DestinyComponentType.ItemStats,
            DestinyComponentType.ItemSockets,
            DestinyComponentType.ItemTalentGrids,
            DestinyComponentType.ItemCommonData,
            DestinyComponentType.ItemPlugStates,
            DestinyComponentType.ItemPlugObjectives,
            DestinyComponentType.ItemReusablePlugs,

            DestinyComponentType.Vendors,
            DestinyComponentType.VendorCategories,
            DestinyComponentType.VendorSales,

            DestinyComponentType.Kiosks,
            DestinyComponentType.CurrencyLookups,
            DestinyComponentType.PresentationNodes,
            DestinyComponentType.Collectibles,
            DestinyComponentType.Records,
            DestinyComponentType.Transitory,
            DestinyComponentType.Metrics
        };

        private static IBungieClient _bungieClient;

        static void Main(string[] args)
        {
            _bungieClient = BungieApiBuilder.GetApiClient((settings) =>
            {
                settings
                    .AddApiKey(key: args[0])
                    .AddClientIdAndSecret(id: int.Parse(args[1]), secret: args[2])
                    .SpecifyApplicationScopes(ApplicationScopes.ReadUserData)
                    .UseLocalManifestFiles(@"H:\BungieNetCoreAPIRepository\Manifests")
                    .EnableLogging()
                    .PremapDefinitions()
                    .LoadAllDefinitionsOnStartup()
                    .SetLocales(new BungieLocales[] { BungieLocales.EN })
                    .SetUpdateBehaviour(true, true);
            });

            _bungieClient.AddListener((mes) => Console.WriteLine(mes));
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            // var profile = await _bungieClient.ApiAccess.Destiny2.GetProfile(
            //     BungieMembershipType.TigerSteam,
            //     4611686018483306402,
            //     ALL_COMPONENTS_ARRAY);

            // var shouldUpdate = await _bungieClient.CheckUpdates();
            // if (shouldUpdate)
            //     await _bungieClient.DownloadLatestManifestLocally();

            //_bungieClient.LoadDefinitions();
            await Task.Delay(Timeout.Infinite);
        }

        private static void RunDeepEqualityCheck<T>(List<T> collection) where T : IDeepEquatable<T>
        {
            var sw = new Stopwatch();
            sw.Start();
            var uniqueItems = 0;
            foreach (var item in collection)
            {
                var equalCount = 0;
                foreach (var itemNested in collection)
                {
                    if (item.DeepEquals(itemNested))
                    {
                        equalCount++;
                    }
                }

                if (equalCount == 1)
                    uniqueItems++;
            }

            sw.Stop();
            Console.WriteLine($"{sw.ElapsedMilliseconds} ms elapsed. Unique items: {uniqueItems}");
        }

        private static long MeasureOperation(Action action, bool writeResult = true)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            action.Invoke();
            sw.Stop();
            if (writeResult)
                Console.WriteLine($"{sw.ElapsedMilliseconds} ms elapsed.");
            return sw.ElapsedMilliseconds;
        }

        private static void MeasureOperationMultiple(Action action, int amount)
        {
            double totalTime = 0.0;
            for (int i = 0; i < amount; i++)
            {
                totalTime += MeasureOperation(action, false);
            }

            Console.WriteLine($"Ran op {amount} times in {totalTime} ms ({totalTime / amount} per op.)");
        }

        private static async Task UserApiTest()
        {
            var getBungieNetUserByIdResponse = await _bungieClient.ApiAccess.User.GetBungieNetUserById(20027802);
            var searchUsersResponse = await _bungieClient.ApiAccess.User.SearchUsers("megl");
            var getCredentialTypesForTargetAccountResponse =
                await _bungieClient.ApiAccess.User.GetCredentialTypesForTargetAccount(getBungieNetUserByIdResponse
                    .Response.MembershipId);
            var getAvailableThemesResponse = await _bungieClient.ApiAccess.User.GetAvailableThemes();
            var getMembershipDataByIdResponse = await _bungieClient.ApiAccess.User.GetMembershipDataById(
                getBungieNetUserByIdResponse.Response.MembershipId, Models.BungieMembershipType.TigerSteam);
            //var getMembershipDataForCurrentUserResponse = await _bungieClient.ApiAccess.User.GetMembershipDataForCurrentUser();
            var getMembershipFromHardLinkedCredentialResponse =
                await _bungieClient.ApiAccess.User.GetMembershipFromHardLinkedCredential(76561198083556532);
        }

        private static async Task AppApiTest()
        {
            var getBungieApplicationsResponse = await _bungieClient.ApiAccess.App.GetBungieApplications();
            var getApplicationApiUsageResponse =
                await _bungieClient.ApiAccess.App.GetApplicationApiUsage(getBungieApplicationsResponse.Response[0]
                    .ApplicationId);
        }

        private static async Task ContentApiTest()
        {
            var getContentTypeResponse = await _bungieClient.ApiAccess.Content.GetContentType("News");
            var getContentByIdResponse = await _bungieClient.ApiAccess.Content.GetContentById(50223, "en");
            var getContentByTagAndTypeResponse =
                await _bungieClient.ApiAccess.Content.GetContentByTagAndType("News", "destiny-news", "en");
            var searchContentWithTextResponse =
                await _bungieClient.ApiAccess.Content.SearchContentWithText("en", new string[] {"News"}, "twab", null,
                    "destiny-news");
            var searchContentByTagAndTypeResponse =
                await _bungieClient.ApiAccess.Content.SearchContentByTagAndType("en", "destiny-news", "News");
        }

        private static async Task TrendingApiTest()
        {
            var getTrendingCategoriesResponse = await _bungieClient.ApiAccess.Trending.GetTrendingCategories();
            var getTrendingCategoryResponse = await _bungieClient.ApiAccess.Trending.GetTrendingCategory("News");
            var getTrendingEntryDetailResponse =
                await _bungieClient.ApiAccess.Trending.GetTrendingEntryDetail(TrendingEntryType.News,
                    getTrendingCategoryResponse.Response.Results[0].Identifier);
        }
    }
}