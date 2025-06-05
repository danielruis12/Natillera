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
                return "proveedor insertado correctamente";
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
                    return "El proveedor con el documento ingresado no existe";

                dbNatillera.Proveedors.AddOrUpdate(proveedor);
                dbNatillera.SaveChanges();
                return "proveedor actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el proveedor: " + ex.Message;
            }
        }

        public Proveedor Consultar(int id)
        {
            return dbNatillera.Proveedors.FirstOrDefault(c => c.id == id);
        }

    }
}