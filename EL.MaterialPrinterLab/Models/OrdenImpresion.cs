using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MaterialPrinterLab.Models
{
    public class OrdenImpresion
    {
        public int Id { get; set; }

        public Item ItemFinal { get; set; }

        public Impresora Impresora { get; set; }

        public int DuracionEstimada { get; set; }

        public string Solicitante { get; set; }

        public string Estado { get; set; }

        public DateTime FechaEjecucion { get; set; }

        public DateTime FechaFinalizacion { get; set; }

        
    }
}
