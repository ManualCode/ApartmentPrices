namespace ApartmentPrices.API.Contracts
{
    public record SubscriptionResponse(Guid id, String Email, DateTime CreatedAt, List<ApartmentResponse> Apartments);
}
