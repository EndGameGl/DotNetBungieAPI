using System.Globalization;
using System.Text;
using System.Threading;
using DotNetBungieAPI.Models.Destiny;

namespace DotNetBungieAPI;

internal class ExtendedStringBuilder
{
    private readonly object _lock = new();
    private readonly Dictionary<string, string> _optionalUrlParams = new();
    private readonly StringBuilder _sb = new();

    private CancellationTokenRegistration _currentTokenRegistration;

    public ExtendedStringBuilder()
    {
        IsBusy = false;
    }

    public bool IsBusy { get; private set; }

    public ExtendedStringBuilder PrepareForUse(CancellationToken ct)
    {
        lock (_lock)
        {
            IsBusy = true;
            _currentTokenRegistration = ct.Register(() =>
            {
                _sb.Clear();
                _optionalUrlParams.Clear();
                IsBusy = false;
            });
            return this;
        }
    }

    public ExtendedStringBuilder Append(string value)
    {
        _sb.Append(value);
        return this;
    }

    public ExtendedStringBuilder Append(long value)
    {
        _sb.Append(value);
        return this;
    }

    public ExtendedStringBuilder Append(uint value)
    {
        _sb.Append(value);
        return this;
    }

    public ExtendedStringBuilder Append(char value)
    {
        _sb.Append(value);
        return this;
    }

    public ExtendedStringBuilder Append(int value)
    {
        _sb.Append(value);
        return this;
    }

    public ExtendedStringBuilder Append(bool value)
    {
        _sb.Append(value);
        return this;
    }

    public ExtendedStringBuilder AddUrlParam(string value)
    {
        _sb.Append(value).Append('/');
        return this;
    }

    public ExtendedStringBuilder AddQueryParam(string key, string? value)
    {
        if (string.IsNullOrEmpty(value))
            return this;

        _optionalUrlParams.Add(key, value);
        return this;
    }

    public ExtendedStringBuilder AddQueryParam(string key, bool value)
    {
        return AddQueryParam(key, value.ToString());
    }

    public ExtendedStringBuilder AddQueryParam(string key, int value)
    {
        return AddQueryParam(key, value.ToString());
    }

    public ExtendedStringBuilder AddQueryParam(string key, DateTime value)
    {
        return AddQueryParam(key, value.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture));
    }

    public ExtendedStringBuilder AddQueryParam(string key, DestinyComponentType[] value)
    {
        return AddQueryParam(key, value.ComponentsToIntString());
    }

    public ExtendedStringBuilder AddQueryParam<T>(string key, T[] value)
        where T : Enum
    {
        return AddQueryParam(key, string.Join(',', value.Select(x => x.ToString())));
    }

    public ExtendedStringBuilder AddQueryParam(string key, string value, Func<bool> predicate)
    {
        if (predicate())
            _optionalUrlParams.Add(key, value);
        return this;
    }

    public string Build()
    {
        lock (_lock)
        {
            var result = string.Empty;
            switch (_optionalUrlParams.Count)
            {
                case 0:
                    result = _sb.ToString();
                    break;
                case > 0:
                {
                    _sb.Append('?');
                    var iterator = 1;
                    foreach (var (key, value) in _optionalUrlParams)
                    {
                        _sb.Append(key).Append('=').Append(value);
                        if (iterator < _optionalUrlParams.Count)
                            _sb.Append('&');
                        iterator++;
                    }

                    result = _sb.ToString();
                    break;
                }
            }

            _sb.Clear();
            _optionalUrlParams.Clear();
            IsBusy = false;
            _currentTokenRegistration.Dispose();
            return result;
        }
    }
}
