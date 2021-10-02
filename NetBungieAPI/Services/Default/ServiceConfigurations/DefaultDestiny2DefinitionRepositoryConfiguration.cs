using System;
using System.Collections.Generic;
using System.Linq;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;

namespace NetBungieAPI.Services.Default.ServiceConfigurations
{
    public class DefaultDestiny2DefinitionRepositoryConfiguration
    {
        private int _appConcurrencyLevel = Environment.ProcessorCount;
        public List<BungieLocales> UsedLocales { get; } = new List<BungieLocales>();

        internal List<DefinitionsEnum> AllowedDefinitions { get; } = Enum.GetValues<DefinitionsEnum>().ToList();

        public int AppConcurrencyLevel
        {
            get => _appConcurrencyLevel;
            set => _appConcurrencyLevel = Conditions.Int32MoreThan(value, 0);
        }

        private void IgnoreDefinitionType(DefinitionsEnum definitionType)
        {
            AllowedDefinitions.Remove(definitionType);
        }
    }
}