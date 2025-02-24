using ApartmentPrices.DataAcces.Entities;
using ApartmentPrices.Domain.Models;
using AutoMapper;


namespace ApartmentPrices.DataAcces.Mapper.Profilies
{
    public class PriceHistoryMapperProfile: Profile
    {
        public PriceHistoryMapperProfile()
        {
            CreateMap<PriceHistoryEntity, PriceHistory>();

            CreateMap<PriceHistory, PriceHistoryEntity>().ForMember(dest => dest.Apartment, opt => opt.Ignore());
        }
    }
}
