namespace BankApp.Core.Domain.Entities
{
    public class Balance
    {
        public int BalanceId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
        public int? AccountId { get; set; }
        public Account? Account { get; set; }
    }
}
