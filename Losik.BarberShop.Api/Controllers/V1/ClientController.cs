using Losik.BarberShop.Api.Controllers.V1.Base;
using Losik.BarberShop.Domain.Dtos.Clients;
using Losik.BarberShop.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Losik.BarberShop.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ApiV1BaseController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _clientService.List());

        [HttpGet]
        [Route("/api/client/{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id) => Ok(await _clientService.Get(id));

        [HttpPost]
        public async Task<IActionResult> Post(ClientDto dto)
        {
            var result = await _clientService.Add(dto);
            return result.Success ?
                Ok(result) :
                BadRequest(result);
        }

        [HttpDelete]
        [Route("/api/client/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _clientService.Delete(id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put()
        {
            return Ok();
        }
    }
}
