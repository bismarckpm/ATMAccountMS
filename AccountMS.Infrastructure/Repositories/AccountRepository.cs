using AccountMS.Core.Repositories;
using AccountMS.Domain.Entities;
using AccountMS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AccountMS.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDbContext _dbContext;

        public AccountRepository(AccountDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Account?> GetByIdAsync(Guid accountId)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
        }

        public async Task AddAsync(Account account)
        {
            await _dbContext.Accounts.AddAsync(account);
            await _dbContext.SaveChangesAsync();
        }
    }
}
