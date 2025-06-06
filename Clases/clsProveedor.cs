using Natillera.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Natillera.Clases
{
    public class clsProveedor
    {
        private NatilleraDBEntities dbNatillera = new NatilleraDBEntities();
        public Proveedor proveedor { get; set; }

        public string Insertar()
        {
            try
            {
                dbNatillera.Proveedors.Add(proveedor);
                dbNatillera.SaveChanges();
                return "Proveedor insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el proveedor: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Proveedor pro = Consultar(proveedor.id);
                if (pro == null)
                    return "El proveedor con el id ingresado no existe";

                dbNatillera.Proveedors.AddOrUpdate(proveedor);
                dbNatillera.SaveChanges();
                return "Proveedor actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el proveedor: " + ex.Message;
            }
        }

        public List<Proveedor> ConsultarTodos()
        {
            return dbNatillera.Proveedors.OrderBy(p => p.Nombre).ToList();
        }

        public Proveedor Consultar(int id)
        {
            return dbNatillera.Proveedors.FirstOrDefault(c => c.id == id);
        }
        public string Eliminar()
        {
            try
            {
                Proveedor pro = Consultar(proveedor.id);
                if (pro == null)
                    return "El proveedor no existe";

                dbNatillera.Proveedors.Remove(pro);
                dbNatillera.SaveChanges();
                return "Proveedor eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el proveedor: " + ex.Message;
            }
        }

        public string Eliminar(int id)
        {
            try
            {
                Proveedor pro = Consultar(id);
                if (pro == null)
                    return "El proveedor no existe";

                dbNatillera.Proveedors.Remove(pro);
                dbNatillera.SaveChanges();
                return "Proveedor eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el proveedor: " + ex.Message;
            }
        }

    }
}