using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstaCore.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int? InstitutionId { get; set; }
        [UIHint("String")]
        public string Description { get; set; }
        [UIHint("Currency")]
        public Currency Currency { get; set; }
        public AccountType Type { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }

    public enum Currency
    {
        CAD, USD
    }

    public enum AccountType
    {
        Investment, Checking, Savings, Deposit, Prepaid
    }
}
