using DotNetBungieAPI.OpenApi.CodeGeneration;

namespace DotNetBungieAPI.OpenApi.CSharp.Library.AdditionalFileGenerators;

public class BungieLocaleFileGenerator : AdditionalFileGenerator
{
    private const string Content = """
        namespace DotNetBungieAPI.Models;

        /// <summary>
        ///     Enumeration for available locales on bungie.net
        /// </summary>
        public enum BungieLocales
        {
            /// <summary>
            ///     English
            /// </summary>
            EN,

            /// <summary>
            ///     Russian
            /// </summary>
            RU,

            /// <summary>
            ///     German
            /// </summary>
            DE,

            /// <summary>
            ///     Spanish
            /// </summary>
            ES,

            /// <summary>
            ///     Spanish (Mexico)
            /// </summary>
            ES_MX,

            /// <summary>
            ///     French
            /// </summary>
            FR,

            /// <summary>
            ///     Italian
            /// </summary>
            IT,

            /// <summary>
            ///     Japanese
            /// </summary>
            JA,

            /// <summary>
            ///     Korean
            /// </summary>
            KO,

            /// <summary>
            ///     Polish
            /// </summary>
            PL,

            /// <summary>
            ///     Portuguese (Brazil)
            /// </summary>
            PT_BR,

            /// <summary>
            ///     Chinese (Simplified)
            /// </summary>
            ZH_CHS,

            /// <summary>
            ///     Chinese (Traditional)
            /// </summary>
            ZH_CHT
        }
        """;

    public override string FileNameAndExtension => "BungieLocales.cs";
    public override string Location => "Models";

    public override async Task WriteFile(Models.OpenApi openApiModel)
    {
        await WriteAsync(Content);
    }
}
