using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea8.DTO
{
    public class ProductDTO
    {
        public string Nombre { get; set; }


        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
