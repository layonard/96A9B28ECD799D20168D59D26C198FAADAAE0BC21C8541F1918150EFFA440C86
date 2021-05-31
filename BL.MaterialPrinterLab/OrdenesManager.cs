using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.MaterialPrinterLab;
using EL.MaterialPrinterLab.Model;
using EL.MaterialPrinterLab.Reportes;

namespace BL.MaterialPrinterLab
{
    public class OrdenesManager
    {
        private ItemsRepository itemsRespository;
        private ImpresorasRepository impresorasRepository;

        public OrdenesManager(string CadenaConexion)
        {
            var dbAccess = new MaterialPrinterContext(CadenaConexion);
            itemsRespository = new ItemsRepository(dbAccess);
            impresorasRepository = new ImpresorasRepository(dbAccess);
        }

        

        

    }
}
