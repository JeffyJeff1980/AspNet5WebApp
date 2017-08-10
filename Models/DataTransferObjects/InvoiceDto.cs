using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstaCore.Models.DataTransferObjects
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public int InstitutionId { get; set; }
        public string Participant { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public decimal TotalNetCharge { get; set; }
        public bool IsReceived { get; set; }
    }
}
