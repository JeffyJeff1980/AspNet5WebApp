using InstaCore.Models;
using System.Collections.Generic;

namespace InstaCore.Models.DataTransferObjects
{
  public class AccountInstitutionDto
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public InstitutionType Type { get; set; }
    public ICollection<AccountSummaryDto> BankAccounts { get; set; }
    public ICollection<InvoiceDto> InvoiceAccounts { get; set; }
    public ICollection<AccountSummaryDto> InvestAccounts { get; set; }
  }
}
