namespace AccountMS.Commons.Dtos.Request
{
    public record CreateAccountDto
    {
        public Guid ClientId { get; set; }
        public string? AccountNumber { get; init; }
        public string? Currency { get; init; }
        public string? AccountType { get; init; }
        public decimal InitialBalance { get; init; }
    }
}
