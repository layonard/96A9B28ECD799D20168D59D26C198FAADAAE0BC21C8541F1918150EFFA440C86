using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MaterialPrinterLab.Model
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        [Required]
        public int Tiempo { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public bool EsBase { get; set; }

        [NotMapped]
        public List<Insumo> Receta { get; set; }
    }
}
