using Microsoft.AspNetCore.Mvc;

namespace TerraForums.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
