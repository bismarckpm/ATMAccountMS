namespace AccountMS.Commons.Dtos.Respose
{
    public class GetAccountDto
    {
        public Guid Id { get; set; }
        public string? AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string? Currency { get; set; }
        public string? AccountType { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
    }
}
