using AutoMapper;
using Losik.BarberShop.CrossCutting.Mappers.Converters;
using Losik.BarberShop.Domain.Dtos.Clients;
using Losik.BarberShop.Domain.Models;

namespace Losik.BarberShop.CrossCutting.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ClientDto, Client>().ConvertUsing<ClientDtoToClientConverter>();
            CreateMap<Client, ClientDto>().ConvertUsing<ClientToClientDtoConverter>();
        }
    }
}
