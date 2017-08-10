using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using InstaCore.Data;
using InstaCore.Models.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstaCore.ViewComponents
{
    [ViewComponent(Name = "ProfitLossInvoiceTotals")]
    public class ProfitLossInvoiceTotalsComponent : ViewComponent
    {
        private readonly QuantContext _quantContext;
        private readonly IMapper _mapper;

        public ProfitLossInvoiceTotalsComponent(QuantContext context, IMapper mapper)
        {
            _quantContext = context;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(IEnumerable<InstitutionInvoiceDto> institutionInvoiceDto)
        {
            return View("ProfitLossInvoiceTotals", institutionInvoiceDto);
        }
    }
}
