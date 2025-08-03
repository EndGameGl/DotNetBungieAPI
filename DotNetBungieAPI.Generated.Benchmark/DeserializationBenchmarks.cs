using System.Text.Json;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Attributes;
using DotNetBungieAPI.Generated.Models;
using DotNetBungieAPI.Generated.Models.Destiny.Responses;

namespace DotNetBungieAPI.Generated.Benchmark;

[MemoryDiagnoser]
public class DeserializationBenchmarks
{
    private byte[] _getProfile;
    private JsonSerializerOptions _serializerOptions;
    
    [GlobalSetup]
    public async Task Setup()
    {
        _getProfile = await File.ReadAllBytesAsync(string.Empty);

        _serializerOptions = new JsonSerializerOptions()
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };
        _serializerOptions.TypeInfoResolverChain.Insert(0, DotNetBungieAPIJsonSerializationContext.Default);
    }

    [Benchmark]
    public ApiResponse<DestinyProfileResponse>? DeserializeProfileBenchmark()
    {
        return JsonSerializer.Deserialize<ApiResponse<DestinyProfileResponse>>(_getProfile, _serializerOptions);
    }
}
