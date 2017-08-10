using InstaCore.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstaCore.Helpers
{
    public static class ChartDataHelper
    {
        public static IEnumerable<WeekTotalsDto> GetWeekTotals(IEnumerable<InvoiceDto> invoices)
        {
            var results = new List<WeekTotalsDto>();
            var groups = invoices
                .Where(o => o.InvoiceDate > DateTime.Now.AddMonths(-6))
                .GroupBy(q => String.Format("{0}{1}", q.InvoiceDate.GetWeekOfYear(), q.InvoiceDate.Year));

            foreach (var group in groups)
            {
                var weekTotalDto = new WeekTotalsDto()
                {
                    DateWeek = DateHelper.GetWeekStartDate(group.First().InvoiceDate),
                    WeekTotal = group.Sum(o => o.TotalNetCharge * -1),
                };

                results.Add(weekTotalDto);
            }

            return results;
        }

        public static IEnumerable<WeekTotalsDto> GetWeekTotalsCumul(IEnumerable<InvoiceDto> invoices)
        {
            decimal runningTotal = 0;

            var results = new List<WeekTotalsDto>();
            var groups = invoices
                .OrderBy(p => p.InvoiceDate)
                .GroupBy(q => String.Format("{0}{1}", q.InvoiceDate.GetWeekOfYear(), q.InvoiceDate.Year));

            foreach (var group in groups)
            {
                var weekTotalDto = new WeekTotalsDto()
                {
                    DateWeek = DateHelper.GetWeekStartDate(group.First().InvoiceDate),
                    RunningTotal = runningTotal += group.Sum(o => o.TotalNetCharge * -1)
                };

                results.Add(weekTotalDto);
            }

            return results;
        }
    }
}
