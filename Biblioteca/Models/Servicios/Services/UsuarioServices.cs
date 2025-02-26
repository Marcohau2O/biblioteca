using Biblioteca.Context;
using Biblioteca.Models.Domain;
using Biblioteca.Models.Servicios.IServices;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace Biblioteca.Models.Servicios.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        public readonly ApplicationDbContext _context;
        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //Crear una funcion para obtener las lista de usuarios
        public List<Usuario> GetUsuarios()
        {
            try
            {
                List<Usuario> result = _context.Usuario.Include(u => u.Roles).ToList();
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception("Succesio un Error" + ex.Message);
            }
        }

        //Funcion Para crear un Usuario
        public bool Create(Usuario req)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = req.Nombre,
                    UserName = req.UserName,
                    Password = BCrypt.Net.BCrypt.HashPassword(req.Password),
                    FkRol = req.FkRol,
                };

                _context.Usuario.Add(usuario);
                var result =_context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al Crear el usuario" + ex.Message);       
            }
        }

        public Usuario GetbyId(int id)
        {
            try
            {
                Usuario usuario = _context.Usuario.FirstOrDefault(x => x.PkUsuario == id);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio Un Error" + ex.Message);
            }
        }

        public Usuario Editar(Usuario usuarioEdit)
        
        {
            try
            {
                Usuario usuario = _context.Usuario.FirstOrDefault(x => x.PkUsuario == usuarioEdit.PkUsuario);
                if (usuario == null)
                {
                    throw new Exception("Usuario no encontrado");
                }

                usuario.Nombre = usuarioEdit.Nombre;
                usuario.UserName = usuarioEdit.UserName;
                usuario.Password =  BCrypt.Net.BCrypt.HashPassword(usuarioEdit.Password);
                usuario.FkRol = usuarioEdit.FkRol;

                _context.Usuario.Update(usuario);
                _context.SaveChangesAsync();

                return usuario;

            } catch(Exception ex)
            {
                throw new Exception("Error al Editar Usuario" + ex.Message);
            }

        }

        public bool EliminarUsuario(int id)
        {
            try
            {
                var usuario = _context.Usuario.FirstOrDefault(x => x.PkUsuario == id);
                if (usuario != null)
                {
                    _context.Usuario.Remove(usuario);
                    _context.SaveChanges();
                    return true;
                }

                return false;

            } catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
    }
}
