using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.Model;
using MiPrimeraApi.Repository;

namespace MiPrimeraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsuarioController : ControllerBase
    {
        //Usuario usuarioActual;

        [HttpGet (Name = "ConseguirUsuarios")]
        public Usuario GetUsuario(string nombreUsuario)
        {
            Usuario usuarioActual = UsuarioHandler.TraerUsuario(nombreUsuario);
            return usuarioActual;
        }

        //[HttpDelete (Name = "EliminarUsuario")]
        //public bool DeleteUsuario([FromBody] int id)
        //{
        //    return UsuarioHandler.EliminarUsuario(id);
        //}

        //[HttpPut (Name = "AgregarUsuario")]
        //public bool AddUsuario([FromBody] Usuario usuario)
        //{
        //    return UsuarioHandler.CrearUsuario(usuario);
        //}

        [HttpPut (Name = "ActualizarUsuario")]
        public bool UpdateUsuario(Usuario usuario/*string nombreUsuario |string nombreUsuarioACambiar,string nuevoNombre, string nuevoApellido, string nuevoNombreUsuario,*/
            /*string nuevoConstraseña, string nuevoMail*/)
        {
            //Usuario usuarioActual = UsuarioHandler.TraerUsuario(nombreUsuario);
            bool usuarioModExitosa = UsuarioHandler.ModificarUsuario(usuario/*usuarioActual |nuevoNombre, nuevoApellido, nuevoNombreUsuario, nuevoConstraseña, nuevoMail*/);
            return usuarioModExitosa;
        }
    }
}
