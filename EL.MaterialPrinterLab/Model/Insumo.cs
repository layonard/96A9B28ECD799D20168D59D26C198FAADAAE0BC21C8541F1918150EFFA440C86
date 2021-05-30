using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MaterialPrinterLab.Model
{
    public class Insumo
    {

        [Required]
        [ForeignKey("Item")]
        public int ItemId { get; set; }

        public Item Item { get; set; }

        [Required]
        [ForeignKey("InsumoItem")]
        public int InsumoId { get; set; }

        public Item InsumoItem { get; set; }
        
        [Required]
        public int Cantidad { get; set; }
    }
}
