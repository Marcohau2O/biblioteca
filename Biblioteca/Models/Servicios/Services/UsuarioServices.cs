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
    }
}
