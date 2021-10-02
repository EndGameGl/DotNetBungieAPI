using System;
using System.Collections.Generic;
using System.Linq;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny;

namespace DotNetBungieAPI.Services.Default.ServiceConfigurations
{
    public sealed class DefaultDestiny2DefinitionRepositoryConfiguration
    {
        private int _appConcurrencyLevel = Environment.ProcessorCount;
        public List<BungieLocales> UsedLocales { get; } = new List<BungieLocales>();

        internal List<DefinitionsEnum> AllowedDefinitions { get; } = Enum.GetValues<DefinitionsEnum>().ToList();

        public int AppConcurrencyLevel
        {
            get => _appConcurrencyLevel;
            set => _appConcurrencyLevel = Conditions.Int32MoreThan(value, 0);
        }

        public void IgnoreDefinitionType(DefinitionsEnum definitionType)
        {
            AllowedDefinitions.Remove(definitionType);
        }
    }
}