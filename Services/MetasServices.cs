using Parcial1_Ap1_RandyFabian.DAL;
using Parcial1_Ap1_RandyFabian.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Parcial1_Ap1_RandyFabian.Services
{
    public class  MetasServices
    {
        private readonly Context _context;

        public  MetasServices(Context context)
        {
            _context = context;
        }

        public async Task<Metas?> Buscar(int metaId)
        {
            return await _context.Metas 
                .Where(i => i.MetaId == metaId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Eliminar(Metas metas)
        {
            _context.Entry(await _context.Metas.FindAsync(metas.MetaId)).State = EntityState.Detached;
            _context.Entry(metas).State = EntityState.Deleted;
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Existe(int metaId)
        {
            return await _context.Metas.AnyAsync(i => i. MetaId == metaId);
        }

       public async Task<bool> Guardar(Metas meta)
        {
            if (await Existe(meta.MetaId))
                return await Modificar(meta);
            else
                return await Insertar(meta);
        }

        public async Task<bool> Insertar(Metas meta)
        {
            await _context.Metas.AddAsync( meta);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Metas meta)
        {
            _context.Entry(await _context.Metas.FindAsync(meta.MetaId)).State = EntityState.Detached;
            _context.Entry(meta).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Metas>> GetList(Expression<Func<Metas, bool>> criterio)
        {
            return await _context.Metas
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}