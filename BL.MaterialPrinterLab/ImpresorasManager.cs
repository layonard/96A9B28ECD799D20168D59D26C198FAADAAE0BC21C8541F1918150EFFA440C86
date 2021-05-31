using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.MaterialPrinterLab;
using EL.MaterialPrinterLab.Model;

namespace BL.MaterialPrinterLab
{
    public class ImpresorasManager
    {
        private ImpresorasRepository impresorasRepository;

        public ImpresorasManager(string CadenaConexion)
        {
            var dbAccess = new MaterialPrinterContext(CadenaConexion);
            impresorasRepository = new ImpresorasRepository(dbAccess);
        }

        public List<Impresora> ObtenerImpresorasLibres()
        {
            return impresorasRepository
                .ObtenerTodo()
                .Where(i => !i.Imprimiendo)
                .ToList();
        }
    }
}
