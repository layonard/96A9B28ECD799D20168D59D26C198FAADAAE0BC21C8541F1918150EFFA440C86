using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MaterialPrinterLab.Model
{
    public class OrdenImpresion
    {
        public int Id { get; set; }

        [Required]
        public Item Item { get; set; }

        [Required]
        public Impresora Impresora { get; set; }

        [Required]
        public int DuracionEstimada { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Solicitante { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public EstadoOrden Estado { get; set; }

        public DateTime FechaEjecucion { get; set; }

        public DateTime FechaFinalizacion { get; set; }
    }

    public enum EstadoOrden
    {
        Pendiente,
        EnEjecucion,
        Finalizado
    }
}
