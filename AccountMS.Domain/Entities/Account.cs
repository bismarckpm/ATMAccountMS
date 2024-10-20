using AccountMS.Commons.Enums;

namespace AccountMS.Domain.Entities
{
    public class Account : Base
    {
        public Guid ClientId { get; private set; }
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public string Currency { get; private set; }
        public AccountType AccountType { get; private set; }
        public string? Description { get; private set; }

        public Account(Guid clientId, string accountNumber, AccountType accountType, string currency, decimal initialBalance)
        {
            ClientId = clientId;
            AccountNumber = accountNumber;
            AccountType = accountType;
            Currency = currency;
            Balance = initialBalance;
        }

        public Account() { }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");
            if (Balance < amount)
                throw new InvalidOperationException("Insufficient balance.");

            Balance -= amount;
        }
    }
}
