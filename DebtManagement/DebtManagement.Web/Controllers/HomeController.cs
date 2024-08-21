using DebtManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DebtManagement.Web.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace DebtManagement.Web.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    ViewBag.ClientId = user.Id;
                }
                else
                {
                    ViewBag.ClientId = "Client ID not found";
                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
