using System.Collections.Generic;
using System.Linq;

namespace NetBungieAPI
{
    public class RequestQueryBuilder
    {
        private Dictionary<string, string> _values;

        public RequestQueryBuilder()
        {
            _values = new Dictionary<string, string>();
        }
        public RequestQueryBuilder Add(string key, string value)
        {
            _values.Add(key, value);
            return this;
        }
        public string Build()
        {
            return $"?{string.Join('&', _values.Select(x => $"{x.Key}={x.Value}"))}";
        }
    }
}
