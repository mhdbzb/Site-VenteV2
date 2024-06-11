using Microsoft.AspNetCore.Mvc;

namespace GestionAchats.Controllers
{
    public class PanierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
