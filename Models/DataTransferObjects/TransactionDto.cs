using InstaCore.Models;
using System;

namespace InstaCore.Models.DataTransferObjects
{
    public class TransactionDto
    { 
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Balance { get; set; }
    }
}
