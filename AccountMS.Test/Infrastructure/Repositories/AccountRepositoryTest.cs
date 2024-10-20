using AccountMS.Core.Database;
using AccountMS.Infrastructure.Repositories;
using AccountMS.Test.Data.DataSeed;
using AccountMS.Test.Data.MockData;
using Moq;
using Xunit;

namespace AccountMS.Test.Infrastructure.Repositories
{
    public class AccountRepositoryTest
    {
        private readonly AccountRepository _repository;
        private readonly Mock<IAccountDbContext> _contextMock;

        public AccountRepositoryTest()
        {
            _contextMock = new Mock<IAccountDbContext>();

            _repository = new AccountRepository(_contextMock.Object);
            _contextMock.SetupDbContextData();
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnAccount_WhenAccountExists()
        {
            // Arrange
            var accountId = new Guid("9250e385-b632-45d7-8e19-556b5eacea09");

            // Act
            var account = await _repository.GetByIdAsync(accountId);

            // Assert
            Assert.NotNull(account);
            Assert.Equal(accountId, account.Id);
        } 
        
        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenAccountDoesNotExist()
        {
            // Arrange
            var accountId = new Guid("9250e385-b632-45d7-8e19-556b5eacea00");

            // Act
            var account = await _repository.GetByIdAsync(accountId);

            // Assert
            Assert.Null(account);
        }

        [Fact]
        public async Task AddAsync_ShouldAddAccount()
        {
            // Arrange
            var account = BuildDataContextFaker.BuildCreateAccountEntity();

            // Act
            await _repository.AddAsync(account);

            // Assert
            _contextMock.Verify(x => x.Accounts.AddAsync(account, It.IsAny<CancellationToken>()), Times.Once);
            _contextMock.Verify(x => x.SaveEfContextChanges("",CancellationToken.None), Times.Once);
        }
    }
}
