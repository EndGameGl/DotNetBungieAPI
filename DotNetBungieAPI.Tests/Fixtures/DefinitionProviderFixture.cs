using System.Threading.Tasks;
using DotNetBungieAPI.Service.Abstractions;
using Xunit;

namespace DotNetBungieAPI.Tests.Fixtures
{
    public class DefinitionProviderFixture : IAsyncLifetime
    {
        public IDefinitionProvider DefinitionProvider { get; private set; }

        public DefinitionProviderFixture(IDefinitionProvider definitionProvider)
        {
            DefinitionProvider = definitionProvider;
        }

        public async Task InitializeAsync()
        {
            await DefinitionProvider.Initialize();
        }

        public async Task DisposeAsync()
        {
            await DefinitionProvider.DisposeAsync();
        }
    }
}
