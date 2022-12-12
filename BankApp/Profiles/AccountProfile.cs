using AutoMapper;
using BankApp.Application.DTOs;
using BankApp.Core.Domain.Entities;

namespace BankApp.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
        }
    }
}
