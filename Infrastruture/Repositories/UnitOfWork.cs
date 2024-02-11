using Domain.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Infrastruture.Context;
using Domain.Exceptions;
using Domain.Commons;

namespace Infrastruture.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _dbContext;
        private IDbContextTransaction _transaccion;

        public UnitOfWork(AppDbContext contexto)
        {
            _dbContext = contexto;
        }


        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing || _dbContext == null) return;
            ((DbContext)_dbContext).Dispose();
            _dbContext = null;
        }

        public void BeginTransaction()
        {
            _transaccion = ((AppDbContext)_dbContext).Database.BeginTransaction();
        }

        public void ClearTracking()
        {
            ((DbContext)_dbContext).ChangeTracker.Clear();
        }

        public void Commit()
        {
            try
            {
                _transaccion?.Commit();
            }
            catch (Exception ex)
            {
                throw new AppException($"Error  en {nameof(UnitOfWork)}.{CallerMember.GetNameMethod()}: {ex.Message}",
                    ex);
            }
        }

        public void RollBack()
        {
            _transaccion?.Rollback();
        }

        public async Task SaveChanges()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new AppException($"Error  en {nameof(UnitOfWork)}.{CallerMember.GetNameMethod()}: {ex.Message}",
                    ex);
            }
        }
    }
}
