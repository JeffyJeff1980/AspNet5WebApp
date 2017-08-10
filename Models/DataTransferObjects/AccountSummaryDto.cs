using InstaCore.Models;
using System.Collections.Generic;

namespace InstaCore.Models.DataTransferObjects
{
  public class AccountSummaryDto
  {
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public AccountType Type { get; set; }
    public string Description { get; set; }
    public ICollection<TransactionDto> Transactions { get; set; }
    public double Balance { get; set; }
  }
}
