using AccountMS.Application.Queries;
using AccountMS.Commons.Dtos.Respose;
using AccountMS.Core.Repositories;
using AccountMS.Infrastructure.Exceptions;
using MediatR;

namespace AccountMS.Application.Handlers.Queries
{
    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, GetAccountDto>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<GetAccountDto> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByIdAsync(request.Id);

            if (account == null)
                throw new AccountNotFoundException("Account not found.");

            return new GetAccountDto
            {
                Id = account.Id,
                AccountNumber = account.AccountNumber,
                Balance = account.Balance,
                Currency = account.Currency,
                AccountType = account.AccountType.ToString()
            };
        }
    }
}
