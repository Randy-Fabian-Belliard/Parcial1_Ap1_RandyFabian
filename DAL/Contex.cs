using Microsoft.EntityFrameworkCore;
using Parcial1_Ap1_RandyFabian.Models;

namespace Parcial1_Ap1_RandyFabian.DAL
{
    public class Context : DbContext
    {
        public DbSet< Metas>  Metas;

        public Context(DbContextOptions<Context> options) : base(options) { }
    }
}
