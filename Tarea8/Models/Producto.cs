using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea8.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre ")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe colocar el Precio ")]

        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        #region //fk
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }

        #endregion


        #region //Navigation Property
        public Proveedor ProveedorN { get; set; }
        public Categoria CategoriaN { get; set; }

        #endregion
    }
}
