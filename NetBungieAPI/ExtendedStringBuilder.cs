using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NetBungieAPI
{
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

        public ExtendedStringBuilder AddQueryParam(string key, string value)
        {
            _optionalUrlParams.Add(key, value);
            return this;
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
}