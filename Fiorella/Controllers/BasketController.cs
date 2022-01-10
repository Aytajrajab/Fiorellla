using Microsoft.AspNetCore.Mvc;

namespace Fiorella.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
