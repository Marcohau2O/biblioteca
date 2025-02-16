using Biblioteca.Models.Domain;

namespace Biblioteca.Models.Servicios.IServices
{
    public interface IRolServices
    {
        public Task<List<Rol>> GetAllRol();
        public List<Rol> GetRol();
        public bool Create(Rol req);

        public Rol GetRolById(int id);

        public Rol Editar(Rol rol);

        public bool EliminarRol(int id);
    }
}
