using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InstaCore.Models
{
    public class Institution
    {
        public int Id { get; set; }
        [UIHint("String")]
        public string Description { get; set; }
        public InstitutionType Type { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }

    public enum InstitutionType
    {
        Bank, Market
    }
}
