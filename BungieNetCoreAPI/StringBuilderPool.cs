using System.Collections.Generic;
using System.Linq;

namespace NetBungieAPI
{
    internal static class StringBuilderPool
    {
        private static List<StringBuilderInstance> _builders;
        static StringBuilderPool()
        {
            _builders = new List<StringBuilderInstance>();
        }

        public static StringBuilderInstance GetBuilder()
        {
            StringBuilderInstance builder = _builders.FirstOrDefault(x => !x.IsBusy);
            if (builder is null)
            {
                builder = new StringBuilderInstance();
                _builders.Add(builder);
            }
            builder.PrepareForUse();
            return builder;
        }
    }
}
