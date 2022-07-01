using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using DotNetBungieAPI.Tests.Fixtures;
using Xunit;
using Xunit.Priority;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace DotNetBungieAPI.Tests
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    [DefaultPriority(int.MaxValue)]
    public class DefinitionProviderTests : IClassFixture<DefinitionProviderFixture>
    {
        private readonly DefinitionProviderFixture _definitionProviderFixture;

        public DefinitionProviderTests(DefinitionProviderFixture definitionProviderFixture)
        {
            _definitionProviderFixture = definitionProviderFixture;
        }

        [Fact]
        public async Task AssertDefinitionLoads()
        {
            var witheringBladeDefinition =
                await _definitionProviderFixture.DefinitionProvider.LoadDefinition<DestinyInventoryItemDefinition>(
                    1341767667,
                    BungieLocales.EN);
            Assert.NotNull(witheringBladeDefinition);
            Assert.Equal("Withering Blade", witheringBladeDefinition.DisplayProperties.Name);
        }

        [Fact]
        public async Task AssertHistoricalStatDefinitionLoads()
        {
            var activitiesClearedDefinition = await _definitionProviderFixture.DefinitionProvider.LoadHistoricalStatsDefinition(
                "activitiesCleared",
                BungieLocales.EN);
            Assert.NotNull(activitiesClearedDefinition);
            Assert.Equal("Activities Cleared", activitiesClearedDefinition.StatName);
        }
    }
}