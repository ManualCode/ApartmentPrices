using ApartmentPrices.DataAcces.Entities;
using ApartmentPrices.Domain.Models;
using AutoMapper;
using System.Numerics;


namespace ApartmentPrices.DataAcces.Mapper.Profilies
{
    public class ApartmentMapperProfile : Profile
    {
        public ApartmentMapperProfile()
        {
            CreateMap<ApartmentEntity, Apartment>()
                .ForMember(ap => ap.Subscriptions, opt => opt.MapFrom(a => a.Subscriptions.Select(y => y.Subscription).ToList())).MaxDepth(2);


            CreateMap<Apartment, ApartmentEntity>();

        }
    }
}
