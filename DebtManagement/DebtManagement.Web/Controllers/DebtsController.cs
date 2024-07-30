using DebtManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DebtManagement.Web.Controllers
{ 
    public class DebtsController : Controller
    {
        private readonly DebtsService debtsService;

        public DebtsController(DebtsService debtsService)
        {
            this.debtsService = debtsService;
        }

        public IActionResult Index()
        {
            var debts = await debtsService.GetAllDebtsAsync();
            return View(debts);
        }
    }
}
