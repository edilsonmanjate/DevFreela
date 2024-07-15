using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    public class ProjectsController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}
