using System;
using System.ComponentModel.DataAnnotations;

namespace InstaCore.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int? InstitutionId { get; set; }
        [UIHint("String")]
        public string Participant { get; set; }
        public string InvoiceNumber { get; set; }
        [UIHint("Date")]
        public DateTime InvoiceDate { get; set; }
        [UIHint("Date")]
        public DateTime? PaymentDueDate { get; set; }
        public decimal TotalNetCharge { get; set; }
        [UIHint("Boolean")]
        public bool? IsReceived { get; set; }
    }
}
