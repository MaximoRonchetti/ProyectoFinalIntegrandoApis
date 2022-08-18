using Microsoft.AspNetCore.Mvc;

namespace MiPrimeraApi.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
