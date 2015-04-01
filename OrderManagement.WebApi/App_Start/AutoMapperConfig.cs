
namespace OrderManagement.WebApi
{
    using AutoMapper;
    using OrderManagement.DataAccess;
    using OrderManagement.WebApi.Models;

    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper
                .CreateMap<Order, OrderViewModel>()
                .ForMember(
                    target => target.CustomerName,
                    options => options.MapFrom(source => source.Customer.Name));
        }
    }
}