using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class TestController : Controller
    {


        public IActionResult Index()
        {

            return View();
        }

        [Authorize()]
        public IActionResult Protected()
        {
            return View();
        }

    }
}
