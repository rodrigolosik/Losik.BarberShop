using Losik.BarberShop.Domain.Models.Base;
using System;

namespace Losik.BarberShop.Domain.Models
{
    public class Client : BaseModel
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
