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
    [RoutePrefix("api/Proveedor")]
    [Authorize]
    public class ProveedorController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Proveedor> ConsultarTodos()
        {
            clsProveedor proveedor = new clsProveedor();
            return proveedor.ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultarxid")]
        public Proveedor ConsultarxId(int id)
        {
            clsProveedor proveedor = new clsProveedor();
            return proveedor.Consultar(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Proveedor proveedorParam)
        {
            clsProveedor proveedor = new clsProveedor();
            proveedor.proveedor = proveedorParam;
            return proveedor.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Proveedor proveedorParam)
        {
            clsProveedor proveedor = new clsProveedor();
            proveedor.proveedor = proveedorParam;
            return proveedor.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Proveedor proveedorParam)
        {
            clsProveedor proveedor = new clsProveedor();
            proveedor.proveedor = proveedorParam;
            return proveedor.Eliminar();
        }

        [HttpDelete]
        [Route("Eliminarxid")]
        public string EliminarxDocumento(int documento)
        {
            clsProveedor proveedor = new clsProveedor();
            return proveedor.Eliminar(documento);
        }

    }
}