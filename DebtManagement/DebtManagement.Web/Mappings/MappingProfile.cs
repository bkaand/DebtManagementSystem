using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Entities;

namespace DebtManagement.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //mappings go here
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Debt, DebtDTO>().ReverseMap();
           // CreateMap<Income, IncomeDTO>().ReverseMap();
            CreateMap<Payment, PaymentDTO>().ReverseMap(); 
        
        }
    }
}
