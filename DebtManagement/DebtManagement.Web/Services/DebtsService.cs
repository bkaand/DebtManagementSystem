/*using DebtManagement.Web.Entities;
using DebtManagement.Web.Repositories;

namespace DebtManagement.Web.Services
{
    public class DebtsService
    {

        private readonly IDebtRepository _debtRepository;

        public DebtsService(IDebtRepository debtRepository)
        {
            _debtRepository = debtRepository;
        }


        public async Task<IEnumerable<Debt>> GetAllDebtsAsync() 
        { 
            var debts = await _debtRepository.GetAllDebtsAsync();

            return debts;
        }
    }
}*/
using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Entities;
using DebtManagement.Web.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Services
{
    public class DebtsService : IDebtsService
    {
        private readonly IDebtRepository _debtRepository;
        private readonly IMapper _mapper;

        public DebtsService(IDebtRepository debtRepository, IMapper mapper)
        {
            _debtRepository = debtRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DebtDTO>> GetAllDebtsAsync()
        {
            var debts = await _debtRepository.GetAllDebtsAsync();
            return _mapper.Map<IEnumerable<DebtDTO>>(debts);
        }
    }
}
