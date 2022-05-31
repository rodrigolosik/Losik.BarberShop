using Losik.BarberShop.Domain.Interfaces.Repositories;
using Losik.BarberShop.Infra.Context;
using Losik.BarberShop.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Losik.BarberShop.IoC
{
    public static class RepositoriesIoC
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<DbSession>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IClientRepository, ClientRepository>();
        }
    }
}
