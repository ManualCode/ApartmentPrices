namespace ApartmentPrices.API.Contracts
{
    public record ApartmentResponse(
        Guid Id, String Url, String Adddress, List<PriceHistoryResponse> priceHistory);
}
