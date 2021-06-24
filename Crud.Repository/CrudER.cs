using System.Linq;
using System.Threading.Tasks;
using Crud.Domain;
using Microsoft.EntityFrameworkCore;

namespace Crud.Repository
{
    public class CrudER : ICrud
    {
        private readonly Context _context;
        public CrudER(Context context)
        {
            _context = context;
        }
        public void Add(Usuario usuario)
        {
            _context.Add(usuario);
        }
        public void Update(Usuario usuario)
        {
            _context.Remove(usuario);
        }
        public void Delete(Usuario usuario)
        {
           _context.Remove(usuario);
        }

        public  async Task<Usuario[]> GetAllUsuario()
        {
            IQueryable<Usuario> query = _context.Usuarios;
            return await query.ToArrayAsync() ; 
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            IQueryable<Usuario> query = _context.Usuarios;
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync() > 0 );
        }
    }
}