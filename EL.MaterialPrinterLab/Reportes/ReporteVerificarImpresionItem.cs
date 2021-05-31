using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MaterialPrinterLab.Reportes
{
    public class ReporteVerificarImpresionItem
    {
        public int ItemId { get; set; }
        public string NombreItem { get; set; }
        public int InsumoId { get; set; }
        public string NombreInsumo { get; set; }
        public int CantidadNecesaria { get; set; }
        public int CantidadExistente { get; set; }
        public bool SeImprime { get; set; }
        public int CantidadAImprimir { get; set; }
        public int Tiempo { get; set; }
        public int ImpresoraId { get; set; }
        public string ImpresoraNombre { get; set; }
    }
}
