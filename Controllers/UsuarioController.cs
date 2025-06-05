using Natillera.Clases;
using Natillera.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Natillera.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Usuarios")]
    [Authorize]
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("CrearUsuario")]
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
        [HttpDelete]
        [Route("Eliminar")]
        public IHttpActionResult Eliminar(int id)
        {
            clsUsuario Usuario = new clsUsuario();
            string resultado = Usuario.EliminarUsuario(id);

            if (resultado.Contains("correctamente"))
                return Ok(resultado);
            else
                return BadRequest(resultado);
        }

    }
}