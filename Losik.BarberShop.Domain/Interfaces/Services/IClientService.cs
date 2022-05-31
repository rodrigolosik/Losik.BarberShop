using Losik.BarberShop.Domain.Dtos.Clients;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Losik.BarberShop.Domain.Interfaces.Services
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> List();
        Task<ClientDto> Get(Guid id);
        Task<ResponseDeleteClientDto> Delete(Guid id);
        Task<ResponseAddClientDto> Add(ClientDto dto);
        Task<ResponseUpdateClientDto> Update(Guid id, ClientDto dto);
    }
}
