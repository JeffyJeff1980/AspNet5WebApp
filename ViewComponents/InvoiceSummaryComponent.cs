using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using InstaCore.Data;
using InstaCore.Models.DataTransferObjects;
using System.Threading.Tasks;

namespace InstaCore.ViewComponents
{
    [ViewComponent(Name = "InvoiceSummary")]
    public class InvoiceSummaryComponent : ViewComponent
    {
        private readonly QuantContext _quantContext;
        private readonly IMapper _mapper;

        public InvoiceSummaryComponent(QuantContext context, IMapper mapper)
        {
            _quantContext = context;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(InvoiceDto invoiceDto)
        {
            return View("InvoiceSummary", invoiceDto);
        }
    }
}
