using Losik.BarberShop.Domain.Dtos.Base;
using System;

namespace Losik.BarberShop.Domain.Dtos.Clients
{
    public class ClientDto : BaseDto
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
