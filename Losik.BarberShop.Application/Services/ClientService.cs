using AutoMapper;
using FluentValidation;
using Losik.BarberShop.Domain.Dtos.Clients;
using Losik.BarberShop.Domain.Interfaces.Repositories;
using Losik.BarberShop.Domain.Interfaces.Services;
using Losik.BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Losik.BarberShop.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<ClientDto> _clientDtoValidator;

        public ClientService(IClientRepository clientRepository, IMapper mapper, IValidator<ClientDto> clientDtoValidator)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _clientDtoValidator = clientDtoValidator;
        }

        public async Task<ResponseAddClientDto> Add(ClientDto dto)
        {
            var response = new ResponseAddClientDto();

            var validation = await _clientDtoValidator.ValidateAsync(dto);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    response.AddError(error.ErrorMessage);

                return response;
            }

            var client = _mapper.Map<Client>(dto);

            var success = await _clientRepository.Add(client);

            if (!success)
            {
                response.AddError("Error to add a new client");
            }

            return response;
        }

        public async Task<ClientDto> Get(Guid id)
        {
            var client = await _clientRepository.Get(id);

            var clientDto = _mapper.Map<ClientDto>(client);

            return clientDto;
        }

        public async Task<IEnumerable<ClientDto>> List()
        {
            var clients = await _clientRepository.List();

            var clientsDto = _mapper.Map<IEnumerable<ClientDto>>(clients);

            return clientsDto;
        }

        public async Task<ResponseDeleteClientDto> Delete(Guid id)
        {
            var response = new ResponseDeleteClientDto();

            var clientExists = Get(id);

            if (clientExists is null)
                response.AddError("Client not found");

            var success = await _clientRepository.Delete(id);

            if (!success)
                response.AddError("Error processing delete request");

            return response;
        }

        public async Task<ResponseUpdateClientDto> Update(Guid id, ClientDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
