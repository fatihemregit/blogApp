using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
