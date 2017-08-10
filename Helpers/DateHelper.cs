using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace InstaCore.Helpers
{
    public static class DateHelper
    {
        static GregorianCalendar _gc = new GregorianCalendar();
     
        /// </summary>
        /// <param name="invoiceDate"></param>
        /// <returns>
        /// Less than zero:
        ///     t1 is earlier than t2.
        /// Zero:
        ///     t1 is the same as t2.
        /// Greater than zero:
        ///     t1 is later than t2.
        /// </returns>
        public static int EvaluateToFiscalYear(DateTime invoiceDate)
        {
            var now = DateTime.Now;
            var fiscalYear = (now.Month <= 4 ? now.Year + 1 : now.Year);
            var currentFiscalYear = new DateTime(fiscalYear, 04, 01);
            var result = DateTime.Compare(invoiceDate, currentFiscalYear);

            return result;
        }

        public static int GetWeekOfMonth(this DateTime time)
        {
            DateTime first = new DateTime(time.Year, time.Month, 1);
            return time.GetWeekOfYear() - first.GetWeekOfYear() + 1;
        }

        public static int GetWeekOfYear(this DateTime time)
        {
            return _gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }

        public static DateTime GetWeekStartDate(this DateTime dt)
        {
            int diff = dt.DayOfWeek - DayOfWeek.Sunday;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }
    }
}
