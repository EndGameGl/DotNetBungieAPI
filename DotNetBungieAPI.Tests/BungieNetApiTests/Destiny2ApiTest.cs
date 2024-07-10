using System.Threading.Tasks;
using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using DotNetBungieAPI.Service.Abstractions;
using Xunit;

namespace DotNetBungieAPI.Tests.BungieNetApiTests
{
    public class Destiny2ApiTest
    {
        private readonly IBungieClient _bungieClient;

        public Destiny2ApiTest(IBungieClient bungieClient)
        {
            _bungieClient = bungieClient;
        }

        [Fact]
        public async Task Assert_GetDestinyManifest()
        {
            var manifest = await _bungieClient.ApiAccess.Destiny2.GetDestinyManifest();
            Assert.NotNull(manifest);
            Assert.True(manifest.IsSuccessfulResponseCode);
            Assert.NotNull(manifest.Response);
        }

        [Fact]
        public async Task Assert_GetDestinyEntityDefinition()
        {
            var itemDefinition =
                await _bungieClient.ApiAccess.Destiny2.GetDestinyEntityDefinition<DestinyInventoryItemDefinition>(
                    DefinitionsEnum.DestinyInventoryItemDefinition,
                    892360677
                );

            Assert.NotNull(itemDefinition);
            Assert.True(itemDefinition.IsSuccessfulResponseCode);
            Assert.NotNull(itemDefinition.Response);
            Assert.Equal("Iron Fellowship Helm", itemDefinition.Response.DisplayProperties.Name);
        }
    }
}
