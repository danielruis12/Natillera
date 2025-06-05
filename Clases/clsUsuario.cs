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
        public string Actualizar(int Perfil)
        {
            try
            {
                var usuarioExistente = dbNatillera.Usuarios.Find(usuario.id);
                if (usuarioExistente == null)
                    return "Usuario no encontrado";

                usuarioExistente.DocumentoEmpleado = usuario.DocumentoEmpleado;
                usuarioExistente.userName = usuario.userName;

                if (!string.IsNullOrEmpty(usuario.Clave))
                {
                    clsCypher cypher = new clsCypher();
                    cypher.Password = usuario.Clave;
                    if (!cypher.CifrarClave())
                        return "Error cifrando nueva clave";

                    usuarioExistente.Clave = cypher.PasswordCifrado;
                    usuarioExistente.Salt = cypher.Salt;
                }

                var perfilExistente = dbNatillera.Usuario_perfil
                                        .FirstOrDefault(up =>
                                            up.idUsuario == usuario.id &&
                                            up.Activo);

                if (perfilExistente != null)
                {
                    perfilExistente.idPerfil = Perfil;
                }
                else
                {
                    dbNatillera.Usuario_perfil.Add(new Usuario_perfil
                    {
                        idUsuario = usuario.id,
                        idPerfil = Perfil,
                        Activo = true
                    });
                }

                dbNatillera.SaveChanges();
                return "Usuario actualizado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string EliminarUsuario(int idUsuario)
        {
            try
            {
                // En esta parte, se encarga de buscar el usuario
                var usuarioExistente = dbNatillera.Usuarios.Find(idUsuario);
                if (usuarioExistente == null)
                    return "Usuario no encontrado";

                // En esta parte elimina los perfiles asociados, en caso de ser necesario
                var perfiles = dbNatillera.Usuario_perfil.Where(p => p.idUsuario == idUsuario).ToList();
                foreach (var perfil in perfiles)
                {
                    dbNatillera.Usuario_perfil.Remove(perfil);
                }

                dbNatillera.Usuarios.Remove(usuarioExistente);
                dbNatillera.SaveChanges();

                return "Usuario eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el usuario: " + ex.Message;
            }
        }

    }
}