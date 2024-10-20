using AccountMS.Domain.Entities;

namespace AccountMS.Core.Repositories
{
    public interface IAccountRepository
    {
        Task<Account?> GetByIdAsync(Guid accountId);
        Task AddAsync(Account account);
    }
}
