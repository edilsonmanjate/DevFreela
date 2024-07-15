using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
