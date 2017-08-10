using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaCore.Models.DataTransferObjects
{
    public class InstitutionDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public IList<AccountDetailDto> BankAccounts { get; set; }
        public IList<AccountDetailDto> InvoiceAccounts { get; set; }
        public IList<AccountDetailDto> InvestAccounts { get; set; }
    }
}
