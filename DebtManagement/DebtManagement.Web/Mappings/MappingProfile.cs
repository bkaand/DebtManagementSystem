/*using AutoMapper;
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

            CreateMap<Debt, DebtDTO>()
                .ForMember(dest => dest.InstallmentsPaid, opt => opt.MapFrom(src => src.Installments - (int)(src.RemainingAmount / (src.DebtAmount / src.Installments))))
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId));
            CreateMap<DebtDTO, Debt>()
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId));

            //CreateMap<Income, IncomeDto>();
            //CreateMap<IncomeDto, Income>();
            CreateMap<Income, IncomeDto>()
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId));
            CreateMap<IncomeDto, Income>()
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId));

            CreateMap<Payment, PaymentDTO>()
                .ForMember(dest => dest.DebtAmount, opt => opt.MapFrom(src => src.Debt.DebtAmount.ToString()));

            CreateMap<PaymentDTO, Payment>();
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

            CreateMap<Debt, DebtDTO>()
                .ForMember(dest => dest.InstallmentsPaid, opt => opt.MapFrom(src => 
                    src.Installments > 0 ? 
                    src.Installments - (int)(src.RemainingAmount / (src.DebtAmount / src.Installments)) 
                    : 0))
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId));

            CreateMap<DebtDTO, Debt>()
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId));

            CreateMap<Income, IncomeDto>()
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId));
            CreateMap<IncomeDto, Income>()
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId));

            CreateMap<Payment, PaymentDTO>()
                .ForMember(dest => dest.DebtAmount, opt => opt.MapFrom(src => src.Debt.DebtAmount.ToString()));

            CreateMap<PaymentDTO, Payment>();
        }
    }
}
