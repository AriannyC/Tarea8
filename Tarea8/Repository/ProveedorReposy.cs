using Microsoft.EntityFrameworkCore;
using Tarea8.Contex;
using Tarea8.Models;

namespace Tarea8.Repository
{
    public class ProveedorReposy
    {
        private readonly UserContex _contex;

        public ProveedorReposy(UserContex contex)
        {
            _contex = contex;
        }


        public async Task Addasync(Proveedor prove)
        {
            await _contex.AddAsync(prove);
            await _contex.SaveChangesAsync();

        }

        public async Task Deleteasync(Proveedor prove)
        {
            _contex.Set<Proveedor>().Remove(prove);
            await _contex.SaveChangesAsync();

        }
        public async Task Updateasync(Proveedor prove)
        {
            _contex.Entry(prove).State = EntityState.Modified;
            await _contex.SaveChangesAsync();

        }

        public async Task<List<Proveedor>> Getallasync()
        {

            return await _contex.Set<Proveedor>().ToListAsync();

        }
        public async Task<Proveedor?> GetBYId(int id)
        {
            return await _contex.Set<Proveedor>().FindAsync(id);
        }


    }
}

