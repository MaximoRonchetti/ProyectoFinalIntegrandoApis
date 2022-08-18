using Microsoft.AspNetCore.Mvc;

namespace MiPrimeraApi.Controllers
{
    public class ProductoVendidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
