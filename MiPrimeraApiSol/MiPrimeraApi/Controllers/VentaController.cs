using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.Model;
using MiPrimeraApi.Repository;

namespace MiPrimeraApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        [HttpPost (Name = "Agregar Venta")]
        public void AddVenta([FromBody]List<Producto> productos, int idUsuario)
        {
            VentaHandler.AgergarVenta (productos, idUsuario);
        }
    }
}
