using InstaCore.Models;
using InstaCore.Models.DataTransferObjects;
using System.Linq;
using InstaCore.Helpers;
using System;
using System.Collections.Generic;

public class MappingProfile : AutoMapper.Profile
{
  public MappingProfile()
  {
        // Add as many of these lines as you need to map your objects
        CreateMap<ApplicationUser, UserDto>();
        CreateMap<Invoice, InvoiceDto>();
        CreateMap<Institution, InstitutionDto>();
        CreateMap<Transaction, TransactionDto>();

        CreateMap<Account, AccountSummaryDto>()
          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
          .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
          .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
          .ForMember(dest => dest.Balance, opt =>
            opt.MapFrom(src => src.Transactions.OrderByDescending(t => t.TransactionDate).FirstOrDefault().Balance));

        CreateMap<Institution, AccountInstitutionDto>()
          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
          .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
          .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
          .ForMember(dest => dest.BankAccounts, opt => opt.MapFrom(src =>
            src.Accounts.Where(a =>
                a.Type == AccountType.Checking ||
                a.Type == AccountType.Savings ||
                a.Type == AccountType.Prepaid ||
                a.Type == AccountType.Deposit
            )))
          .ForMember(dest => dest.InvestAccounts, opt => opt.MapFrom(src =>
            src.Accounts.Where(a =>
                a.Type == AccountType.Investment
            )))
          .ForMember(dest => dest.InvoiceAccounts, opt => opt.MapFrom(src =>
            src.Invoices.Where(i =>
                i.IsReceived == false
            )));

        CreateMap<Institution, InstitutionInvoiceDto>()
          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
          .ForMember(dest => dest.Invoices, opt => opt.MapFrom(src => src.Invoices))
          .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))

          .ForMember(dest => dest.WeekTotal, opt => opt.MapFrom(src => src.Invoices
            .Where(o => o.InvoiceDate.Year == DateTime.Now.Year && o.InvoiceDate.Month == DateTime.Now.Month &&
              DateHelper.GetWeekOfYear(o.InvoiceDate) == DateHelper.GetWeekOfYear(DateTime.Now))
            .Sum(p => p.TotalNetCharge * -1)))

          .ForMember(dest => dest.MonthTotal, opt => opt.MapFrom(src => src.Invoices
            .Where(o => o.InvoiceDate.Month == DateTime.Now.Month && o.InvoiceDate.Year == DateTime.Now.Year)
            .Sum(p => p.TotalNetCharge * -1)))

          .ForMember(dest => dest.FiscalYearTotal, opt => opt.MapFrom(src => src.Invoices
            .Where(o => DateHelper.EvaluateToFiscalYear(o.InvoiceDate) >= 1)
            .Sum(p => p.TotalNetCharge * -1)))

          .ForMember(dest => dest.CalendarYearTotal, opt => opt.MapFrom(src => src.Invoices
            .Where(o => o.InvoiceDate.Year == DateTime.Now.Year)
            .Sum(p => p.TotalNetCharge * -1)));
  }
}