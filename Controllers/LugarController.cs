using Natillera.Clases;
using Natillera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Natillera.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Lugar")]
    [Authorize]
    public class LugarController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Lugar> ConsultarTodos()
        {
            clsLugar Lugar = new clsLugar();
            return Lugar.ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultarxid")]
        public Lugar ConsultarxId(int id)
        {
            clsLugar Lugar = new clsLugar();
            return Lugar.Consultar(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Lugar LugarParam)
        {
            clsLugar Lugar = new clsLugar();
            Lugar.Lugar = LugarParam;
            return Lugar.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Lugar LugarParam)
        {
            clsLugar Lugar = new clsLugar();
            Lugar.Lugar = LugarParam;
            return Lugar.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Lugar LugarParam)
        {
            clsLugar Lugar = new clsLugar();
            Lugar.Lugar = LugarParam;
            return Lugar.Eliminar();
        }

        [HttpDelete]
        [Route("Eliminarxid")]
        public string EliminarxId(int id)
        {
            clsLugar Lugar = new clsLugar();
            return Lugar.Eliminar(id);
        }

    }
}