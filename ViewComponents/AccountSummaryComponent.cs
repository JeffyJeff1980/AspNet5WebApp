using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using InstaCore.Data;
using InstaCore.Models.DataTransferObjects;
using System.Threading.Tasks;

namespace InstaCore.ViewComponents
{
    [ViewComponent(Name = "AccountSummary")]
    public class AccountSummaryComponent : ViewComponent
    {
        private readonly QuantContext _quantContext;
        private readonly IMapper _mapper;

        public AccountSummaryComponent(QuantContext context, IMapper mapper)
        {
            _quantContext = context;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(AccountSummaryDto accountSummaryDto)
        {
            return View("AccountSummary", accountSummaryDto);
        }
    }
}
