using Losik.BarberShop.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Losik.BarberShop.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T: BaseModel
    {
        Task<bool> Add(T model);
        Task<bool> Update(T model);
        Task<bool> Delete(Guid id);
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> List();
    }
}
