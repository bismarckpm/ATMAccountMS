using System.Linq.Expressions;
using AccountMS.Application.Commands;
using AccountMS.Application.Validators;
using AccountMS.Commons.Enums;
using AccountMS.Core.Repositories;
using AccountMS.Domain.Entities;
using MediatR;

namespace AccountMS.Application.Handlers.Commands
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new CreateAccountValidator();
                await validator.ValidateRequest(request.Account);

                var account = new Account(
                    request.Account.ClientId,
                    request.Account.AccountNumber!,
                    Enum.Parse<AccountType>(request.Account.AccountType!),
                    request.Account.Currency!,
                    request.Account.InitialBalance);

                await _accountRepository.AddAsync(account);

                return account.Id;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
