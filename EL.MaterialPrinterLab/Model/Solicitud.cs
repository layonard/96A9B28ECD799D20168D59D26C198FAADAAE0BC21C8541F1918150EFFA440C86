using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MaterialPrinterLab.Model
{
    public class Solicitud
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Solicitante { get; set; }

        [Required]
        public DateTime FechaSolicitud { get; set; }

        [NotMapped]
        public List<OrdenImpresion> Ordenes { get; set; }
    }
}
