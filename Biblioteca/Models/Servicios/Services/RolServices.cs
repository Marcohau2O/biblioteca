using Biblioteca.Context;
using Biblioteca.Models.Domain;
using Biblioteca.Models.Servicios.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Biblioteca.Models.Servicios.Services
{
    public class RolServices : IRolServices
    {
        public readonly ApplicationDbContext _context;

        public RolServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rol>> GetAllRol()
        {
            try
            {
                List<Rol> resul = await _context.Roles.ToListAsync();
                return resul;

            }
            catch (Exception ex)
            {

                throw new Exception("Surgio erro al obtener roles" + ex.Message);

            }
        }

        public List<Rol> GetRol()
        {
            try
            {
                List<Rol> result = _context.Roles.ToList();
                return result;
            }
                catch (Exception ex) 
            { 

                throw new Exception("Succesion un Error" + ex.Message);
            
            }
        }

        public Rol GetRolById(int id)
        {
            try
            {
                Rol rol = _context.Roles.FirstOrDefault(x => x.PkRol == id);
                return rol;

            }catch (Exception ex)
            {
                throw new Exception("Ocurrio Un Error" + ex.Message);
            }
        }

        public bool Create(Rol req)
        {
            try
            {
                Rol rol = new Rol()
                {
                    Nombre = req.Nombre,
                };

                _context.Roles.Add(rol);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }

                return false;
            } catch (Exception ex)
            {
                throw new Exception("Error al Crear el Rol" + ex.Message);
            }
        }

        public Rol Editar(Rol rol)
        {
            try
            {
                Rol roledit = _context.Roles.FirstOrDefault(x => x.PkRol == rol.PkRol);
                if (roledit == null)
                {
                    throw new Exception("Rol no encontrado");
                }

                roledit.Nombre = rol.Nombre;

                _context.Roles.Update(roledit);
                _context.SaveChangesAsync();

                return roledit;
            } catch (Exception ex)
            {
                throw new Exception("Error al Editar Rol" + ex.Message);
            }
        }

        public bool EliminarRol(int id)
        {
            try
            {
                var rol = _context.Roles.FirstOrDefault(x => x.PkRol == id);
                if (rol != null)
                {
                    _context.Roles.Remove(rol);
                    _context.SaveChanges();
                    return true;
                }

                return false;
            } catch (Exception ex)
            {
                throw new Exception("Sucedio un Error" + ex.Message);
            }
        }
    }
}
