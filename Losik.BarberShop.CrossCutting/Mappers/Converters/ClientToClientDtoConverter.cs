using AutoMapper;
using Losik.BarberShop.Domain.Dtos.Clients;
using Losik.BarberShop.Domain.Models;

namespace Losik.BarberShop.CrossCutting.Mappers.Converters
{
    public class ClientToClientDtoConverter : ITypeConverter<Client, ClientDto>
    {
        public ClientDto Convert(Client source, ClientDto destination, ResolutionContext context) =>
            new()
            {
                BirthDate = source.BirthDate,
                Email = source.Email,
                Name = source.Name,
                PhoneNumber = source.PhoneNumber
            };
    }
}
