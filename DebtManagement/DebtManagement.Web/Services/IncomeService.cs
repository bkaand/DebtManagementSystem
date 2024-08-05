using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Entities;
using DebtManagement.Web.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IMapper _mapper;

        public IncomeService(IIncomeRepository incomeRepository, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IncomeDto>> GetAllIncomesAsync()
        {
            var incomes = await _incomeRepository.GetAllIncomesAsync();
            return _mapper.Map<IEnumerable<IncomeDto>>(incomes);
        }

        public async Task<IncomeDto> GetIncomeByIdAsync(int incomeId)
        {
            var income = await _incomeRepository.GetIncomeByIdAsync(incomeId);
            return _mapper.Map<IncomeDto>(income);
        }

        public async Task AddIncomeAsync(IncomeDto incomeDto)
        {
            var income = _mapper.Map<Income>(incomeDto);
            await _incomeRepository.AddIncomeAsync(income);
        }

        public async Task UpdateIncomeAsync(IncomeDto incomeDto)
        {
            var income = _mapper.Map<Income>(incomeDto);
            await _incomeRepository.UpdateIncomeAsync(income);
        }

        public async Task DeleteIncomeAsync(int incomeId)
        {
            await _incomeRepository.DeleteIncomeAsync(incomeId);
        }
    }
}
