using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.Interfaces
{
    public interface IJsonSerializationHelper
    {
        JsonSerializerOptions Options { get; }
        Task<object> DeserializeAsync(byte[] data, Type type);
        Task<T> DeserializeAsync<T>(byte[] data);
        Task<object> DeserializeAsync(Stream data, Type type);
        Task<T> DeserializeAsync<T>(Stream data);
        object Deserialize(string json, Type type);
        object Deserialize(ReadOnlySpan<byte> data, Type type);
        T Deserialize<T>(string json);
        T Deserialize<T>(byte[] data);
        string Serialize<T>(T obj);
        Task SerializeAsync<T>(Stream stream, T data);
    }
}