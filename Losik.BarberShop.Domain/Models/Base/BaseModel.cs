using System;

namespace Losik.BarberShop.Domain.Models.Base
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
