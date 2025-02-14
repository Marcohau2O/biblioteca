using Biblioteca.Context;
using Biblioteca.Models.Domain;
using Biblioteca.Models.Servicios.IServices;

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
                List<Usuario> result = _context.Usuario.ToList();
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
                    Password = req.Password,
                    FkRol = 1
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
    }
}
