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
        [ForeignKey("Solicitud")]
        public int NumeroSolicitud { get; set; }

        public Solicitud Solicitud { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public Item Item { get; set; }

        public int? ImpresoraId { get; set; }
        
        public Impresora Impresora { get; set; }

        [Required]
        public int DuracionEstimada { get; set; }

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
