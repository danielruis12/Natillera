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
    [RoutePrefix("api/Clientes")]
    //[Authorize]
    public class ClientesController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Cliente> ConsultarTodos()
        {
            clsCliente cliente = new clsCliente();
            return cliente.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarxDocumento")]
        public Cliente ConsultarxDocumento(int documento)
        {
            clsCliente cliente = new clsCliente();
            return cliente.Consultar(documento);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Cliente clienteParam)
        {
            clsCliente cliente = new clsCliente();
            cliente.cliente = clienteParam;
            return cliente.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Cliente clienteParam)
        {
            clsCliente cliente = new clsCliente();
            cliente.cliente = clienteParam;
            return cliente.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Cliente clienteParam)
        {
            clsCliente cliente = new clsCliente();
            cliente.cliente = clienteParam;
            return cliente.Eliminar();
        }

        [HttpDelete]
        [Route("EliminarxDocumento")]
        public string EliminarxDocumento(int documento)
        {
            clsCliente cliente = new clsCliente();
            return cliente.Eliminar(documento);
        }
    }
}