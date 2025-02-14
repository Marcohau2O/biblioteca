using Biblioteca.Models.Domain;

namespace Biblioteca.Models.Servicios.IServices
{
    public interface IRolServices
    {
        public Task<List<Rol>> GetAllRol();
    }
}
