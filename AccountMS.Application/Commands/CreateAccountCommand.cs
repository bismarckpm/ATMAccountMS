using AccountMS.Commons.Dtos.Request;
using MediatR;

namespace AccountMS.Application.Commands
{
    public class CreateAccountCommand : IRequest<Guid>
    {
        public CreateAccountDto Account { get; set; }

        public CreateAccountCommand(CreateAccountDto account)
        {
            Account = account;
        }
    }
}
