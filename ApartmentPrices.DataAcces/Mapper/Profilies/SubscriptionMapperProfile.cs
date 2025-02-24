using ApartmentPrices.DataAcces.Entities;
using ApartmentPrices.Domain.Models;
using AutoMapper;


namespace ApartmentPrices.DataAcces.Mapper.Profilies
{
    public class SubscriptionMapperProfile : Profile
    {
        public SubscriptionMapperProfile()
        {
            CreateMap<SubscriptionEntity, Subscription>()
                .ForMember(sb => sb.Apartments, opt => opt.MapFrom(a => a.Apartments.Select(y => y.Apartment).ToList())).MaxDepth(2);

            CreateMap<Subscription, SubscriptionEntity>()
            .ForMember(dest => dest.Apartments, opt => opt.Ignore());
        }
    }
}
