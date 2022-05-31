using Dapper;
using Losik.BarberShop.Domain.Interfaces.Repositories;
using Losik.BarberShop.Domain.Models;
using Losik.BarberShop.Infra.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Losik.BarberShop.Infra.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DbSession _session;

        public ClientRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<bool> Add(Client model)
        {
            try
            {
                _session.Connection.BeginTransaction();

                var success = await _session.Connection.ExecuteAsync($@"
                    INSERT INTO {nameof(Client)} 
                        (Id, Name, Email, BirthDate, PhoneNumber, CreatedAt) 
                    VALUES 
                        (@id, @name, @email, @birthDate, @phoneNumber, @CreatedAt)"
                , param: new
                {
                    id = Guid.NewGuid(),
                    name = model.Name,
                    email = model.Email,
                    birthDate = model.BirthDate,
                    phoneNumber = model.PhoneNumber,
                    createdAt = DateTime.Now
                }) > 0;

                _session.Transaction.Commit();

                return success;
            }
            catch (Exception)
            {
                _session.Transaction.Rollback();
                return false;
            }
            finally
            {
                _session.Connection.Dispose();
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                _session.Connection.BeginTransaction();

                var success = await _session.Connection.ExecuteAsync($"DELETE FROM {nameof(Client)} WHERE id = @id", param: new { id }) > 0;

                _session.Transaction.Commit();

                return success;

            }
            catch (Exception)
            {
                _session.Transaction?.Rollback();
                return false;
            }
            finally
            {
                _session.Transaction.Dispose();
            }
        }

        public async Task<Client> Get(Guid id) =>
            await _session.Connection.QueryFirstOrDefaultAsync<Client>($"SELECT * FROM {nameof(Client)} WHERE id = @id", new { id });

        public async Task<IEnumerable<Client>> List() =>
          await _session.Connection.QueryAsync<Client>($"SELECT * FROM {nameof(Client)}", transaction: _session.Transaction);

        public async Task<bool> Update(Client model)
        {
            return await _session.Connection.ExecuteAsync($@"
                UPDATE {nameof(Client)} 
                SET 
                    Name = @name, 
                    Email = @email, 
                    PhoneNumber = @phoneNumber, 
                    BirthDate = @birthDate, 
                    UpdatedAt = @updatedAt",
                new
                {
                    name = model.Name,
                    email = model.Email,
                    phoneNumber = model.PhoneNumber,
                    birthDate = model.BirthDate,
                    updatedAt = DateTime.Now
                }) > 0;
        }
    }
}
