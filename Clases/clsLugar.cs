using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Natillera.Models;

namespace Natillera.Clases
{
    public class clsLugar
    {
        private NatilleraDBEntities dbNatillera = new NatilleraDBEntities();
        public Lugar lugar { get; set; }
        public string Insertar()
        {
            try
            {
                dbNatillera.Lugars.Add(lugar);
                dbNatillera.SaveChanges();
                return "Lugar insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el lugar: " + ex.Message;
            }
        }
        public string Actualizar()
        {
            try
            {
                Lugar lug = Consultar(lugar.id);
                if (lug == null)
                    return "El lugar con el id ingresado no existe";
                dbNatillera.Lugars.AddOrUpdate(lugar);
                dbNatillera.SaveChanges();
                return "Lugar actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el lugar: " + ex.Message;
            }
        }
        public List<Lugar> ConsultarTodos()
        {
            return dbNatillera.Lugars.OrderBy(p => p.Nombre).ToList();
        }
        public Lugar Consultar(int id)
        {
            return dbNatillera.Lugars.FirstOrDefault(c => c.id == id);
        }

        public string Eliminar()
        {
            try
            {
                Lugar lug = Consultar(lugar.id);
                if (lug == null)
                    return "El lugar con el id ingresado no existe";
                dbNatillera.Lugars.Remove(lug);
                dbNatillera.SaveChanges();
                return "Lugar eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el lugar: " + ex.Message;
            }
        }

        public string Eliminar(int id)
        {
            try
            {
                Lugar pro = Consultar(id);
                if (pro == null)
                    return "El lugar no existe";

                dbNatillera.Lugars.Remove(pro);
                dbNatillera.SaveChanges();
                return "lugar eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el lugar: " + ex.Message;
            }
        }
    }
}