using Biblioteca.Models.Domain;

namespace Biblioteca.Models.Servicios.IServices
{
    public interface IUsuarioServices
    {
        public List<Usuario> GetUsuarios();
        public bool Create(Usuario req);

        public Usuario GetbyId(int id);

        public Usuario Editar(Usuario usuario);

        public bool EliminarUsuario(int id);
    }
}
