using Natillera.Clases;
using Natillera.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Natillera.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Ahorros")]
    [Authorize]
    public class AhorroController : ApiController
    {
        clsAhorro gestor = new clsAhorro();

        [HttpPost]
        [Route("Insertar")]
        public IHttpActionResult Insertar([FromBody] Ahorro ahorro)
        {
            gestor.ahorro = ahorro;
            var mensaje = gestor.Insertar();
            return Ok(mensaje);
        }

        [HttpPut]
        [Route("Actualizar")]
        public IHttpActionResult Actualizar([FromBody] Ahorro ahorro)
        {
            gestor.ahorro = ahorro;
            var mensaje = gestor.Actualizar();
            return Ok(mensaje);
        }

        [HttpGet]
        [Route("Listar")]
        public IHttpActionResult ConsultarTodos()
        {
            var lista = gestor.ConsultarTodos();
            return Ok(lista);
        }

        [HttpGet]
        [Route("PorCliente")]
        public IHttpActionResult ConsultarPorCliente(int idCliente)
        {
            var lista = gestor.ConsultarPorCliente(idCliente);
            return Ok(lista);
        }

        [HttpDelete]
        [Route("Eliminarxid")]
        public IHttpActionResult Eliminar(int id)
        {
            var mensaje = gestor.Eliminar(id);
            return Ok(mensaje);
        }
    }
}
