using Parcial1_Ap1_RandyFabian.DAL;
using Parcial1_Ap1_RandyFabian.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Parcial1_Ap1_RandyFabian.Services
{
    public class MetasServices
    {
        private readonly Context _context;

        public MetasServices(Context context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(Metas metas)
        {
            await _context.Metas.AddAsync(metas);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Existe(int metaId)
        {
            return await _context.Metas.AnyAsync(m => m.MetaId == metaId);

        }

        public async Task<bool> Modificar(Metas metas)
        {
            _context.Entry(await _context.Metas.FindAsync(metas.MetaId)).State = EntityState.Detached;
            _context.Entry(metas).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Metas metas)
        {
 
            bool descripcionExistente = await ExisteDescripcion(metas.Descripcion);

            if (descripcionExistente)
            {
                return false;
            }
            if (await Existe(metas.MetaId))
                return await Modificar(metas);
            else
                return await Insertar(metas);
        }

        public async Task<bool> Eliminar(Metas metas)
        {
            _context.Entry(await _context.Metas.FindAsync(metas.MetaId)).State = EntityState.Detached;
            _context.Entry(metas).State = EntityState.Deleted;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Metas?> Buscar(int metaId)
        {
            return await _context.Metas
                .Where(i => i.MetaId == metaId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<List<Metas>> GetList(Expression<Func<Metas, bool>> criterio)
        {
            return await _context.Metas
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<bool> ExisteDescripcion(string descripcion)
        {
            return await _context.Metas.AnyAsync(d => d.Descripcion == descripcion);
        }
    }
}