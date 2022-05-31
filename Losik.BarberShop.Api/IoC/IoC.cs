using AutoMapper;
using Losik.BarberShop.CrossCutting.Mappers;
using Losik.BarberShop.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Losik.BarberShop.Api.IoC
{
    public static class IoC
    {
        public static void Register(this IServiceCollection services)
        {
            RegisterServices(services);
            ServicesIoC.RegisterServices(services);
            RepositoriesIoC.RegisterRepositories(services);
            ValidatorsIoC.RegisterValidators(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton(_ => GetMapper());
        }

        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(config => config.AddProfile<MapperProfile>());
            return config.CreateMapper();
        }
    }
}
