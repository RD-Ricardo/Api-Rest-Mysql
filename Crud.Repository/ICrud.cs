using System.Threading.Tasks;
using Crud.Domain;

namespace Crud.Repository
{
    public interface ICrud
    {
         void Add(Usuario usuario);
         void Update( Usuario usuario);
         void Delete(Usuario usuario);
         Task<Usuario[]> GetAllUsuario();
         Task<Usuario> GetUsuario(int id);
         Task<bool> Save();
         
    }
}