using Microsoft.AspNetCore.Mvc;
using DebtManagement.Web.Services;
using DebtManagement.Web.DTOs;
using System.Threading.Tasks;

namespace DebtManagement.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var dashboardData = await _dashboardService.GetDashboardDataAsync();
            return View(dashboardData);
        }
    }
}
