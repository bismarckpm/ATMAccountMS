using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountMS.Application.Handlers.Commands;
using AccountMS.Core.Repositories;
using AccountMS.Test.Data.MockData;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Moq;
using Xunit;

namespace AccountMS.Test.Application.Handlers.Commands
{
    public class CreateAccountCommandHandlerTest
    {
        private readonly CreateAccountCommandHandler _handler;
        private readonly Mock<IAccountRepository> _accountRepositoryMock;

        public CreateAccountCommandHandlerTest()
        {
            _accountRepositoryMock = new Mock<IAccountRepository>();

            _handler = new CreateAccountCommandHandler(_accountRepositoryMock.Object);
        }

        [Fact]
        public async Task ShouldCreateAccountSuccess()
        {
            var command = BuildDataContextFaker.BuildCreateAccountCommand();

            _accountRepositoryMock.Setup(x => 
                    x.AddAsync(It.IsAny<Domain.Entities.Account>()))
                .Returns(Task.CompletedTask);

            var result = await _handler.Handle(command, new System.Threading.CancellationToken());
            Assert.NotNull(result);
            Assert.NotEqual(Guid.Empty, result);
        }

        [Fact]
        public async Task ShouldCreateAccountThrowException()
        {
            var command = BuildDataContextFaker.BuildCreateAccountCommand();

            _accountRepositoryMock.Setup(x =>
                    x.AddAsync(It.IsAny<Domain.Entities.Account>()))
                .Throws(new Exception("Error"));

            var ex = Assert.ThrowsAsync<Exception>(async () =>
            await _handler.Handle(command, new System.Threading.CancellationToken()));
            Assert.IsType<Exception>(ex);
        }

    }
}
