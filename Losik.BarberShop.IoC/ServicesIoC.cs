using Losik.BarberShop.Application.Services;
using Losik.BarberShop.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Losik.BarberShop.IoC
{
    public static class ServicesIoC
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
