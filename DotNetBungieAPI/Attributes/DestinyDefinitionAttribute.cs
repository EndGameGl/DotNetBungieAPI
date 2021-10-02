using System;
using DotNetBungieAPI.Models.Destiny;

namespace DotNetBungieAPI.Attributes
{
    /// <summary>
    /// Marks class as a destiny definition
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DestinyDefinitionAttribute : Attribute
    {
        /// <summary>
        /// Default .ctor
        /// </summary>
        /// <param name="type">Definition type</param>
        /// <param name="isManuallyDisabled">Whether it is currently disabled</param>
        public DestinyDefinitionAttribute(DefinitionsEnum type, bool isManuallyDisabled = false)
        {
            DefinitionEnumType = type;
            IsManuallyDisabled = isManuallyDisabled;
        }

        /// <summary>
        /// Definition type
        /// </summary>
        public DefinitionsEnum DefinitionEnumType { get; }

        /// <summary>
        /// Whether this definition type is currently disabled
        /// </summary>
        public bool IsManuallyDisabled { get; }
    }
}