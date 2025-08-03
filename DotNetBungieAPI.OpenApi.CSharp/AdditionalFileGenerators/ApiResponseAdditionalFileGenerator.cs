using DotNetBungieAPI.OpenApi.CodeGeneration;

namespace DotNetBungieAPI.OpenApi.CSharp.AdditionalFileGenerators;

public class ApiResponseAdditionalFileGenerator : AdditionalFileGenerator
{
    private const string FileContent =
        """
        using DotNetBungieAPI.Generated.Models.Exceptions;
        
        namespace DotNetBungieAPI.Generated.Models;
        
        /// <summary>
        ///     Bungie.net API response
        /// </summary>
        /// <typeparam name="T">Response type</typeparam>
        public class ApiResponse<T>
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
        }                               
        """;
    
    
    public override string FileNameAndExtension => "ApiResponse.cs";
    public override string Location => "Models";

    public override async Task WriteFile(Models.OpenApi openApiModel)
    {
        await WriteAsync(FileContent);
    }
}