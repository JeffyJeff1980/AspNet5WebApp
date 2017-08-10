using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaCore.Models.DataTransferObjects
{
    public class WeekTotalsDto
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public DateTime DateWeek { get; set; }
        public decimal WeekTotal { get; set; }
        public decimal RunningTotal;
    }
}
