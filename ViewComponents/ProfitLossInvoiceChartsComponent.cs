using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using InstaCore.Data;
using InstaCore.Helpers;
using InstaCore.Models.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace InstaCore.ViewComponents
{
    [ViewComponent(Name = "ProfitLossInvoiceCharts")]
    public class ProfitLossInvoiceChartsComponent : ViewComponent
    {
        private readonly QuantContext _quantContext;
        private readonly IMapper _mapper;

        public ProfitLossInvoiceChartsComponent(QuantContext context, IMapper mapper)
        {
            _quantContext = context;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(IEnumerable<InstitutionInvoiceDto> institutionInvoiceDto)
        {
            IEnumerable<InvoiceDto> allInvoices = institutionInvoiceDto.SelectMany(o => o.Invoices);

            var dto = new InstitutionInvoiceDto()
            {
                WeekTotals = ChartDataHelper.GetWeekTotals(allInvoices),
                WeekRunningTotals = ChartDataHelper.GetWeekTotalsCumul(allInvoices)
            };

            return View("ProfitLossInvoiceCharts", dto);
        }
    }
}
