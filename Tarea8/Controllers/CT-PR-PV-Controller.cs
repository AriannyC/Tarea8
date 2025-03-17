using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.MinimalApi;
using Tarea8.Contex;
using Tarea8.DTO;
using Tarea8.Models;
using Tarea8.Repository;

namespace Tarea8.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [ApiController]
    public class CT_PR_PV_Controller : ControllerBase
    {
        private readonly UserContex _context;
        private readonly ProductReposy _repositorio;

        public CT_PR_PV_Controller(UserContex cont, ProductReposy repositorio)
        { 
        
           _context = cont;
            _repositorio = repositorio;
        
        
        }


        [HttpGet("variado")]
        public async Task<IActionResult> Varti(ProductDTO td)
        {
            var vari = await _context.prod.Select(c => new


            {
                min = _context.prod.Min(s => s.Precio),
                max= _context.prod.Max(s => s.Precio),
                sum= _context.prod.Sum(s=> s.Precio),
                prome=_context.prod.Average(s=> s.Precio)





            }).FirstOrDefaultAsync(); 



            return Ok(vari);
        }



        [HttpGet("CateEspecifico")]

        public async Task<IActionResult> CatEspecifi(int idc)
        {
            var tot = await _context.prod.Where(x => x.IdCategoria == idc).ToListAsync();
            return Ok(tot);
        }



        [HttpGet("PROEspecifico")]

        public async Task<IActionResult> Especifi(int idpv)
        {
            var tot = await _context.prod.Where(x => x.IdProveedor == idpv).ToListAsync();
            return Ok(tot);
        }

        [HttpGet("total")]

        public async Task<IActionResult> GetCat()
        {
            var tot = await _context.prod.Where(x=>x.Id>=0).CountAsync();
           return Ok(new { cant=tot });
        }

        // PUT: api/Users/5 actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, Producto user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _repositorio.Updateasync(user);
            return NoContent();

        }

        // POST: api/Users crear
        [HttpPost]
        public async Task<ActionResult<Producto>> PostUser(Producto prodr)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(prodr);
            }
            
           
          await _repositorio.Addasync(prodr);
            return NoContent();
            
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _repositorio.GetBYId(id);
            if (user == null)
            {
                return NotFound();
            }

            await _repositorio.Deleteasync(user);
            return NoContent();
        }


    }
}
