using ApartmentPrices.DataAcces.Mapper.Profilies;
using AutoMapper;


namespace ApartmentPrices.DataAcces.Mapper
{
    public class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<SubscriptionMapperProfile>();
                cfg.AddProfile<ApartmentMapperProfile>();
                cfg.AddProfile<PriceHistoryMapperProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
