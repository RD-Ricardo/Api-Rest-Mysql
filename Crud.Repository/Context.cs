using Crud.Domain;
using Microsoft.EntityFrameworkCore;

namespace Crud.Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }
        public DbSet<Usuario> Usuarios {get; set;}
    }
}