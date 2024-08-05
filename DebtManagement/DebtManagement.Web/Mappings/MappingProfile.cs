/*using AutoMapper;
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
            CreateMap<Income, IncomeDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            
        
        }
    }
}
*/
using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Entities;

namespace DebtManagement.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>();

            CreateMap<Debt, DebtDTO>();
            CreateMap<DebtDTO, Debt>();

            CreateMap<Income, IncomeDto>();
            CreateMap<IncomeDto, Income>();

            CreateMap<Payment, PaymentDTO>();
            CreateMap<PaymentDTO, Payment>();
        }
    }
}
