using Biblioteca.Context;
using Biblioteca.Models.Domain;
using Biblioteca.Models.Servicios.IServices;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models.Servicios.Services
{
    public class RolServices : IRolServices
    {
        public readonly ApplicationDbContext _context;

        public RolServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async  Task<List<Rol>> GetAllRol()
        {
            try
            {
                List<Rol> resul = await _context.Roles.ToListAsync();
                return resul;

            } catch (Exception ex)
            {

                throw new Exception("Surgio erro al obtener roles" + ex.Message);

            }
        }
    }
}
