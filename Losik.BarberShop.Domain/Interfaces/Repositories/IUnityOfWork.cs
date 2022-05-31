using System;

namespace Losik.BarberShop.Domain.Interfaces.Repositories
{
    public interface IUnityOfWork : IDisposable  
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
