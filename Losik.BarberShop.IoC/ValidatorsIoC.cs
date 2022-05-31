using FluentValidation;
using Losik.BarberShop.CrossCutting.Validators.Dtos;
using Losik.BarberShop.Domain.Dtos.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace Losik.BarberShop.IoC
{
    public static class ValidatorsIoC
    {
        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<ClientDto>, AddNewClientDtoValidator>();
        }
    }
}
