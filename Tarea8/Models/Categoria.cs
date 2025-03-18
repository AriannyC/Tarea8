using System.ComponentModel.DataAnnotations;

namespace Tarea8.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre ")]

        public string Nombre{ get; set; }

        //navigation Property
        public virtual ICollection<Producto> ProductosNC { get; set; }
    }
}
