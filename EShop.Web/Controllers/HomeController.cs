using Microsoft.AspNetCore.Mvc;

namespace EShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}