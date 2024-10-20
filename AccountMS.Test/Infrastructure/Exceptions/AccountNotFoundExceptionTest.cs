using AccountMS.Infrastructure.Exceptions;
using Xunit;

namespace AccountMS.Test.Infrastructure.Exceptions
{
    public class AccountNotFoundExceptionTest
    {
        [Fact]
        public void ShouldCreateExceptionWithOutArguments()
        {
            var accountNotFoundException = new AccountNotFoundException();
            Assert.NotNull(accountNotFoundException);
        }

        [Fact]
        public void ShouldCreateExceptionWithMessageArguments()
        {
            var message = "Account not found";
            var accountNotFoundException = new AccountNotFoundException(message);
            Assert.NotNull(accountNotFoundException);
            Assert.Equal(message, accountNotFoundException.Message);
        }

        [Fact]
        public void ShouldCreateExceptionWithMessageAndInnerExceptionArguments()
        {
            var message = "Account not found";
            var innerException = new Exception("Inner exception");
            var accountNotFoundException = new AccountNotFoundException(message, innerException);
            Assert.NotNull(accountNotFoundException);
            Assert.Equal(message, accountNotFoundException.Message);
            Assert.Equal(innerException, accountNotFoundException.InnerException);
        }
        
    }
}
