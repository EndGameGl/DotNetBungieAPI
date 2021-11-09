using System.Threading;

namespace DotNetBungieAPI
{
    internal static class StringBuilderPool
    {
        private static readonly object Lock = new();
        private static readonly List<ExtendedStringBuilder> Builders;

        static StringBuilderPool()
        {
            Builders = new List<ExtendedStringBuilder>();
        }

        internal static ExtendedStringBuilder GetBuilder(CancellationToken ct)
        {
            lock (Lock)
            {
                var builder = Builders.FirstOrDefault(x => !x.IsBusy);
                if (builder is not null)
                    return builder.PrepareForUse(ct);
                builder = new ExtendedStringBuilder();
                Builders.Add(builder);
                return builder.PrepareForUse(ct);
            }
        }
    }
}