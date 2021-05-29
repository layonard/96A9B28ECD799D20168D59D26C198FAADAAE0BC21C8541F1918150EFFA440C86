using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.MaterialPrinterLab;
using EL.MaterialPrinterLab;
using EL.MaterialPrinterLab.Models;

namespace BL.MaterialPrinterLab
{
    public class ItemsManager
    {
        private readonly MaterialPrinterContext _dbAccess;
        private ItemsRepository itemsRespository;

        public ItemsManager(string CadenaConexion)
        {
            itemsRespository = new ItemsRepository(new MaterialPrinterContext(CadenaConexion));
        }

        

    }
}
