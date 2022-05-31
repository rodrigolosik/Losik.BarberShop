using AutoMapper;
using Losik.BarberShop.Domain.Dtos.Clients;
using Losik.BarberShop.Domain.Models;

namespace Losik.BarberShop.CrossCutting.Mappers.Converters
{
    public class ClientDtoToClientConverter : ITypeConverter<ClientDto, Client>
    {
        public Client Convert(ClientDto source, Client destination, ResolutionContext context) =>
            new()
            {
                Name = source.Name,
                BirthDate = source.BirthDate,
                Email = source.Email,
                PhoneNumber = source.PhoneNumber,
            };
    }
}
