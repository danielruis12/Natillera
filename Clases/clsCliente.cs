using Natillera.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Natillera.Clases
{
    public class clsCliente
    {
        private NatilleraDBEntities dbNatillera = new NatilleraDBEntities();
        public Cliente cliente { get; set; }

        public string Insertar()
        {
            try
            {
                dbNatillera.Clientes.Add(cliente);
                dbNatillera.SaveChanges();
                return "Cliente insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el cliente: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Cliente cli = Consultar(cliente.Documento);
                if (cli == null)
                    return "El cliente con el documento ingresado no existe";

                dbNatillera.Clientes.AddOrUpdate(cliente);
                dbNatillera.SaveChanges();
                return "Cliente actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el cliente: " + ex.Message;
            }
        }

        public List<Cliente> ConsultarTodos()
        {
            return dbNatillera.Clientes.OrderBy(c => c.Apellido).ToList();
        }

        public Cliente Consultar(int documento)
        {
            return dbNatillera.Clientes.FirstOrDefault(c => c.Documento == documento);
        }

        public string Eliminar()
        {
            try
            {
                Cliente cli = Consultar(cliente.Documento);
                if (cli == null)
                    return "El cliente no existe";

                dbNatillera.Clientes.Remove(cli);
                dbNatillera.SaveChanges();
                return "Cliente eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el cliente: " + ex.Message;
            }
        }

        public string Eliminar(int documento)
        {
            try
            {
                Cliente cli = Consultar(documento);
                if (cli == null)
                    return "El cliente no existe";

                dbNatillera.Clientes.Remove(cli);
                dbNatillera.SaveChanges();
                return "Cliente eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el cliente: " + ex.Message;
            }
        }
    }
}