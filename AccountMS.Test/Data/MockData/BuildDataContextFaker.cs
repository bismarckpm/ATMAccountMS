using AccountMS.Application.Commands;
using AccountMS.Commons.Dtos.Request;
using AccountMS.Commons.Enums;
using AccountMS.Domain.Entities;

namespace AccountMS.Test.Data.MockData
{
    public static class BuildDataContextFaker
    {
        public static Account BuildCreateAccountEntity()
        {
            var account = new Account(new Guid("c0869fe3-0236-4542-9b46-18fb2e209822"), "", AccountType.Checking, "USD", 100)
            {
                Id = new Guid("1f1e3e2d-1b1a-1c1f-1a1b-1c1d1e1f1a1b"),
                CreatedAt = DateTime.Now,
                CreatedBy = "System"
            };
            return account;

        }

        public static CreateAccountCommand BuildCreateAccountCommand()
        {
            var account = new CreateAccountDto()
            {
                ClientId = new Guid("c0869fe3-0236-4542-9b46-18fb2e209822"),
                AccountNumber = "8985644652345",
                AccountType = AccountType.Checking.ToString(),
                Currency = "USD",
                InitialBalance = 100
            };
            return new CreateAccountCommand(account);
        }
    }
}
