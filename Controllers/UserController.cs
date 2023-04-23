using Microsoft.AspNetCore.Mvc;

namespace CulinaryClub.Controllers
{
    public class UserController : Controller
    {
        [HttpGet("users")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
