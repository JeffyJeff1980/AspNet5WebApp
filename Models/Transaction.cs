using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstaCore.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public TransactionType Type { get; set; }
        [UIHint("Date")]
        public DateTime TransactionDate { get; set; }
        [UIHint("Currency")]
        public decimal Balance { get; set; }
    }

    public enum TransactionType
    {
        Debit, Credit
    }
}
