namespace ApartmentPrices.API.Contracts
{
    public record PriceHistoryResponse(Guid Id, decimal Price, DateTime ChekedAt);
}
