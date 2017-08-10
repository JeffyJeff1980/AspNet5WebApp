using System;

namespace InstaCore.Models.DataTransferObjects
{
  public class AccountTransactionDto
  {
    public DateTime TransactionDate { get; set; }
    public string Description { get; set; }
    public double Amount { get; set; }
  }
}
