using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NetBungieAPI
{
    internal static class StringBuilderPool
    {
        private static object _lock = new();
        private static readonly List<ExtendedStringBuilder> _builders;
        static StringBuilderPool()
        {
            _builders = new List<ExtendedStringBuilder>();
        }

        public static ExtendedStringBuilder GetBuilder(CancellationToken ct)
        {
            lock (_lock)
            {
                var builder = _builders.FirstOrDefault(x => !x.IsBusy);
                if (builder is not null)
                    return builder.PrepareForUse(ct);
                builder = new ExtendedStringBuilder();
                _builders.Add(builder);
                return builder.PrepareForUse(ct);
            }
        }
    }
}
