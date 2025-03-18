using Microsoft.EntityFrameworkCore;
using Tarea8.Contex;
using Tarea8.Models;

namespace Tarea8.Repository
{
    public class CategoriReposy
    {
        private readonly UserContex _contex;

        public CategoriReposy(UserContex contex)
        {
            _contex = contex;
        }


        public async Task Addasync(Categoria cat)
        {
            await _contex.AddAsync(cat);
            await _contex.SaveChangesAsync();

        }

        public async Task Deleteasync(Categoria cat)
        {
            _contex.Set<Categoria>().Remove(cat);
            await _contex.SaveChangesAsync();

        }
        public async Task Updateasync(Categoria cat)
        {
            _contex.Entry(cat).State = EntityState.Modified;
            await _contex.SaveChangesAsync();

        }

        public async Task<List<Categoria>> Getallasync()
        {

            return await _contex.Set<Categoria>().ToListAsync();

        }
        public async Task<Categoria?> GetBYId(int id)
        {
            return await _contex.Set<Categoria>().FindAsync(id);
        }


    }
}

