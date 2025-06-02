using Natillera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Natillera.Clases
{
    public class clsUsuario
    {
        private NatilleraDBEntities dbNatillera = new NatilleraDBEntities();
        public Usuario usuario { get; set; }
        public string CrearUsuario(int idPerfil)
        {
            try
            {
                clsCypher cypher = new clsCypher();
                cypher.Password = usuario.Clave;
                if (cypher.CifrarClave())
                {
                    // Grabar el usuario, se deben leer los datos de la clase cypher con la información encriptada
                    usuario.Clave = cypher.PasswordCifrado;
                    usuario.Salt = cypher.Salt;
                    dbNatillera.Usuarios.Add(usuario);
                    dbNatillera.SaveChanges();
                    // Se debe grabar el perfil del usuario
                    Usuario_perfil UsuarioPerfil = new Usuario_perfil();
                    UsuarioPerfil.idPerfil = idPerfil;
                    UsuarioPerfil.Activo = true;
                    UsuarioPerfil.idUsuario = usuario.id; // El id del Usuario queda grabado en la clase usuario al grabar en la base de datos.
                    dbNatillera.Usuario_perfil.Add(UsuarioPerfil);
                    dbNatillera.SaveChanges();
                    return "Se creó el usuario correctamente";
                }
                else
                {
                    return "No se pudo encriptar la clave del usuario";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}