using System;

namespace NetBungieAPI.Services
{
    [Flags]
    public enum ManifestContentDownloadFilter
    {
        MobileAssetContent = 1,
        MobileGearAssetDataBases = 2,
        MobileWorldContent = 4,
        JsonWorldContent = 16,
        JsonWorldComponentContent = 32,
        MobileClanBannerDatabase = 64
    }
}
