namespace DotNetBungieAPI.Models.Destiny
{
    [Flags]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VendorItemStatus
    {
        Success = 0,
        NoInventorySpace = 1,
        NoFunds = 2,
        NoProgression = 4,
        NoUnlock = 8,
        NoQuantity = 16,
        OutsidePurchaseWindow = 32,
        NotAvailable = 64,
        UniquenessViolation = 128,
        UnknownError = 256,
        AlreadySelling = 512,
        Unsellable = 1024,
        SellingInhibited = 2048,
        AlreadyOwned = 4096,
        DisplayOnly = 8192
    }
}