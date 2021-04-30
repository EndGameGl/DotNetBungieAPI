using NetBungieAPI.Models.Applications;
using NetBungieAPI.Clients;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Models.Trending;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.GroupsV2;
using NetBungieAPI.Models.Queries;
using NetBungieAPI.Models.Requests;
using NetBungieAPI.Providers;
using NetBungieAPI.Services.Interfaces;

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

        static async Task Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _bungieClient = BungieApiBuilder.GetApiClient((settings) =>
            {
                settings
                    .AddApiKey(key: args[0])
                    .AddClientIdAndSecret(id: int.Parse(args[1]), secret: args[2])
                    .SpecifyApplicationScopes(ApplicationScopes.ReadUserData | ApplicationScopes.AdminGroups)
                    .UseLocalManifestFiles(@"H:\BungieNetCoreAPIRepository\Manifests")
                    .EnableLogging((mes) => Console.WriteLine(mes))
                    .PremapDefinitions()
                    .UseDefinitionProvider(new JsonFileDefinitionProvider())
                    //.LoadAllDefinitionsOnStartup(waitEverythingToLoad: true)
                    .SetLocales(new BungieLocales[] {BungieLocales.EN})
                    .SetUpdateBehaviour(false, true);
            });
            sw.Stop();
            

            var allItems = await _bungieClient.Repository.Provider.LoadAllDefinitions<DestinyInventoryItemDefinition>(BungieLocales.EN);
            Console.WriteLine($"Startup in: {sw.ElapsedMilliseconds} ms");
            // var authorizationLink = _bungieClient.GetAuthorizationLink();
            //
            // var code = Console.ReadLine();
            //
            // _bungieClient.ReceiveCode(Console.ReadLine(), code);
            //
            // var token = await _bungieClient.GetAuthorizationToken(code);

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