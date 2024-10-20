using AccountMS.Commons.Enums;
using AccountMS.Core.Database;
using AccountMS.Domain.Entities;
using MockQueryable.Moq;
using Moq;

namespace AccountMS.Test.Data.DataSeed
{
    public static class DataSeed
    {
        public static void SetupDbContextData(this Mock<IAccountDbContext> mockContext)
        {

            var account1 = new Account(new Guid("1a6fd39d-38cd-4d71-9f23-78ec04527643"), "8985644652345",
                AccountType.Checking, "USD", 100)
            {
                Id = new Guid("9250e385-b632-45d7-8e19-556b5eacea09"),
                CreatedAt = DateTime.Now,
                CreatedBy = "System"
            };

            var account2 = new Account(new Guid("f12e4119-fdda-45c2-a5c1-4362d9364b1b"), "2251644652345",
                AccountType.Savings, "USD", 200)
            {
                Id = new Guid("68594f24-ea8e-4ec4-9ebf-bed3f47e344d"),
                CreatedAt = DateTime.Now,
                CreatedBy = "System",
            };

            var account3 = new Account(new Guid("fa35bafc-3b43-4922-b548-6af0e51c8cb0"), "3335644654444",
                AccountType.Checking, "USD", 300)
            {
                Id = new Guid("d4833154-136f-40d7-8850-6e42eb88dda9"),
                CreatedAt = DateTime.Now,
                CreatedBy = "System",
            };

            var accounts = new List<Account> { account1, account2, account3 };

            mockContext.Setup(c => c.Accounts).Returns(accounts.AsQueryable().BuildMockDbSet().Object);
            mockContext.Setup(cx => cx.SaveEfContextChanges(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
        }
    }
}
