using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MaterialPrinterLab.Models
{
    public class Receta
    {
        public int Id { get; set; }

        [Required]
        public Item Insumo { get; set; }
        
        [Required]
        public int Cantidad { get; set; }
    }
}
