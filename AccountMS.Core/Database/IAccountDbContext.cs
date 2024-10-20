using AccountMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountMS.Core.Database
{
    public interface IAccountDbContext
    {
        DbContext DbContext { get; }

        DbSet<Account> Accounts { get; set; }

        IDbContextTransactionProxy BeginTransaction();

        void ChangeEntityState<TEntity>(TEntity entity, EntityState state);

        Task<bool> SaveEfContextChanges(string user, CancellationToken cancellationToken = default);
    }
}
