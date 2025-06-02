using Natillera.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Natillera.Clases
{
    public class clsAhorro
    {
        private NatilleraDBEntities dbNatillera = new NatilleraDBEntities();
        public Ahorro ahorro { get; set; }

        public string Insertar()
        {
            try
            {
                dbNatillera.Ahorroes.Add(ahorro);
                dbNatillera.SaveChanges();
                return "Ahorro insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el ahorro: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Ahorro ah = Consultar(ahorro.id);
                if (ah == null)
                    return "El ahorro con el ID ingresado no existe";

                dbNatillera.Ahorroes.AddOrUpdate(ahorro);
                dbNatillera.SaveChanges();
                return "Ahorro actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el ahorro: " + ex.Message;
            }
        }

        public List<Ahorro> ConsultarTodos()
        {
            return dbNatillera.Ahorroes.OrderBy(a => a.Fecha).ToList();
        }

        public Ahorro Consultar(long id)
        {
            return dbNatillera.Ahorroes.FirstOrDefault(a => a.id == id);
        }

        public List<Ahorro> ConsultarPorCliente(int idCliente)
        {
            return dbNatillera.Ahorroes
                .Where(a => a.idCliente == idCliente)
                .OrderByDescending(a => a.Fecha)
                .ToList();
        }

        public string Eliminar()
        {
            try
            {
                Ahorro ah = Consultar(ahorro.id);
                if (ah == null)
                    return "El ahorro no existe";

                dbNatillera.Ahorroes.Remove(ah);
                dbNatillera.SaveChanges();
                return "Ahorro eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el ahorro: " + ex.Message;
            }
        }

        public string Eliminar(long id)
        {
            try
            {
                Ahorro ah = Consultar(id);
                if (ah == null)
                    return "El ahorro no existe";

                dbNatillera.Ahorroes.Remove(ah);
                dbNatillera.SaveChanges();
                return "Ahorro eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el ahorro: " + ex.Message;
            }
        }
    }
}
