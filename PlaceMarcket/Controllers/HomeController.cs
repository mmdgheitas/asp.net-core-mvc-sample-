using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlaceMarcket.Models;
using System.Diagnostics;

namespace PlaceMarcket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RoleManager<IdentityRole> roleManager;

        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            this.roleManager = roleManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void AddRole(string name)
        {
            IdentityRole role = new IdentityRole();
            role.Name = name;
            roleManager.CreateAsync(role);
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
