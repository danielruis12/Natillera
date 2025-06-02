using Natillera.Clases;
using Natillera.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Natillera.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "https://localhost:44378/", headers: "*", methods: "*")]
    [RoutePrefix("api/Usuarios")]
    public class UsuarioController : ApiController
    {
        
        [HttpPost]
        [Route("Insertar")]
        public string CrearUsuario([FromBody] Usuario usuario, int idPerfil)
        {
            clsUsuario Usuario = new clsUsuario();
            Usuario.usuario = usuario;
            return Usuario.CrearUsuario(idPerfil);
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Usuario usuario, int Perfil) 
        {
            clsUsuario Usuario = new clsUsuario(); 
            Usuario.usuario = usuario;
            return Usuario.Actualizar(Perfil);
        }
    }
}