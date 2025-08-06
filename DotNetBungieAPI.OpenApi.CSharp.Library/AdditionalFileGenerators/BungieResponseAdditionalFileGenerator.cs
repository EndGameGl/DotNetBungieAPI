﻿using DotNetBungieAPI.OpenApi.CodeGeneration;

namespace DotNetBungieAPI.OpenApi.CSharp.Library.AdditionalFileGenerators;

public class BungieResponseAdditionalFileGenerator : AdditionalFileGenerator
{
    private const string FileContent = """
        using DotNetBungieAPI.Models.Exceptions;

        namespace DotNetBungieAPI.Models;

        /// <summary>
        ///     Bungie.net API response
        /// </summary>
        /// <typeparam name="T">Response type</typeparam>
        public sealed class BungieResponse<T>
        {
            /// <summary>
            ///     Response data
            /// </summary>
            [JsonPropertyName("Response")]
            public T Response { get; init; }

            /// <summary>
            ///     Response code
            /// </summary>
            [JsonPropertyName("ErrorCode")]
            public PlatformErrorCodes ErrorCode { get; init; }

            /// <summary>
            ///     How many seconds to wait until next request
            /// </summary>
            [JsonPropertyName("ThrottleSeconds")]
            public int ThrottleSeconds { get; init; }

            /// <summary>
            ///     Response error status
            /// </summary>
            [JsonPropertyName("ErrorStatus")]
            public string ErrorStatus { get; init; }

            /// <summary>
            ///     Response text message
            /// </summary>
            [JsonPropertyName("Message")]
            public string Message { get; init; }

            /// <summary>
            ///     Response message data as multiple lines
            /// </summary>
            [JsonPropertyName("MessageData")]
            public Dictionary<string, string> MessageData { get; init; }

            /// <summary>
            ///     Detailed error trace
            /// </summary>
            [JsonPropertyName("DetailedErrorTrace")]
            public string DetailedErrorTrace { get; init; }

            /// <summary>
            ///     When this response was received
            /// </summary>
            internal DateTime ResponseDate { get; init; } = DateTime.Now;

            /// <summary>
            ///     Whether this request was successful
            /// </summary>
            public bool IsSuccessfulResponseCode => ErrorCode == PlatformErrorCodes.Success;
        }

        """;

    public override string FileNameAndExtension => "BungieResponse.cs";
    public override string Location => "Models";

    public override async Task WriteFile(Models.OpenApi openApiModel)
    {
        await WriteAsync(FileContent);
    }
}
