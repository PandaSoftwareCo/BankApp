using System.Text.Json.Serialization;

namespace BankApp.Core.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AccountType
    {
        Debit,
        Credit
    }
}
