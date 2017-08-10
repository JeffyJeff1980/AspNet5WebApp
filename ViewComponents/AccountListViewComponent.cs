using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InstaCore.Data;
using AutoMapper;
using InstaCore.Models.DataTransferObjects;

namespace InstaCore.Views.AccountSummary.ViewComponents
{
    [ViewComponent(Name = "AccountList")]
    public class AccountListViewComponent : ViewComponent
    {
        private readonly QuantContext _quantContext;
        private readonly IMapper _mapper;

        public AccountListViewComponent(QuantContext context, IMapper mapper)
        {
            _quantContext = context;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(AccountInstitutionDto accountInstitutionDto)
        {
            return View("AccountList", accountInstitutionDto);
        }
    }
}
