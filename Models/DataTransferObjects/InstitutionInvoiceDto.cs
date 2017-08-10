using System.Collections.Generic;

namespace InstaCore.Models.DataTransferObjects
{
    public class InstitutionInvoiceDto
    {
      public int Id { get; set; }
      public string Description { get; set; }
      public double WeekTotal { get; set; }
      public double MonthTotal { get; set; }
      public double FiscalYearTotal { get; set; }
      public double CalendarYearTotal { get; set; }
      public IEnumerable<WeekTotalsDto> WeekTotals { get; set; }
      public IEnumerable<WeekTotalsDto> WeekRunningTotals { get; set; }
      public ICollection<InvoiceDto> Invoices { get; set; }
  }
}
