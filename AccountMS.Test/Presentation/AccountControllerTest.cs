using AccountMS.Application.Commands;
using AccountMS.Controllers;
using AccountMS.Test.Data.MockData;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AccountMS.Test.Presentation
{
    public  class AccountControllerTest
    {
        private readonly AccountController _accountController;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<AccountController>> _loggerMock;

        public AccountControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<AccountController>>();
            _accountController = new AccountController(_loggerMock.Object, _mediatorMock.Object);
        }

        [Fact]
        public async Task CreateAccount_ShouldReturnOk33()
        {
            var createAccountDto = BuildDataContextFaker.GenerateCreateAccountDto();
            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateAccountCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Guid.NewGuid());
            var result = await _accountController.CreateAccount(createAccountDto);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateAccount_ShouldReturnError()
        {
            var createAccountDto = BuildDataContextFaker.GenerateCreateAccountDto();
            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateAccountCommand>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("test error"));
            var ex = Assert.ThrowsAsync<Exception>(async () =>
                await _accountController.CreateAccount(createAccountDto));
            Assert.IsType<Exception>(ex);
        }
    }
}
