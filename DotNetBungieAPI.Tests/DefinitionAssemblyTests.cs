using DotNetBungieAPI.Service.Abstractions;
using Xunit;

namespace DotNetBungieAPI.Tests
{
    public class DefinitionAssemblyTests
    {
        private readonly IDefinitionAssemblyData _definitionAssemblyData;

        public DefinitionAssemblyTests(IDefinitionAssemblyData definitionAssemblyData)
        {
            _definitionAssemblyData = definitionAssemblyData;
        }

        [Fact]
        public void AssertDefinitionTypeCountEquality()
        {
            Assert.Equal(
                _definitionAssemblyData.DefinitionsToTypeMapping.Count, 
                _definitionAssemblyData.TypeToEnumMapping.Count);
        }

        [Fact]
        public void AssertCorrectTypeToEnumMapping()
        {
            foreach (var (enumValue, typeData) in _definitionAssemblyData.DefinitionsToTypeMapping)
            {
                Assert.Equal(enumValue.ToString(), typeData.DefinitionType.Name);
            }
        }
    }
}