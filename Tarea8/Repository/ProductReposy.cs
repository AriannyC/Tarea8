using Microsoft.EntityFrameworkCore;
using Tarea8.Contex;
using Tarea8.Models;

namespace Tarea8.Repository
{
    public class ProductReposy
    {
        private readonly UserContex _contex;

        public ProductReposy(UserContex contex)
        {
            _contex = contex;
        }


        public async Task Addasync(Producto pro)
        {
            await _contex.AddAsync(pro);
            await _contex.SaveChangesAsync();

        }

        public async Task Deleteasync(Producto pro)
        {
            _contex.Set<Producto>().Remove(pro);
            await _contex.SaveChangesAsync();

        }
        public async Task Updateasync(Producto pro)
        {
            _contex.Entry(pro).State = EntityState.Modified;
            await _contex.SaveChangesAsync();

        }

        public async Task<List<Producto>> Getallasync()
        {

            return await _contex.Set<Producto>().ToListAsync();

        }
        public async Task<Producto?> GetBYId(int id)
        {
            return await _contex.Set<Producto>().FindAsync(id);
        }


    }
}
