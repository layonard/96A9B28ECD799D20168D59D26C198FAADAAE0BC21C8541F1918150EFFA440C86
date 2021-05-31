using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.MaterialPrinterLab;
using EL.MaterialPrinterLab;
using EL.MaterialPrinterLab.Model;

namespace BL.MaterialPrinterLab
{
    public class ItemsManager
    {
        private ItemsRepository itemsRespository;
        private RecetasRepository recetasRespository;

        public ItemsManager(string CadenaConexion)
        {
            var dbAccess = new MaterialPrinterContext(CadenaConexion);
            itemsRespository = new ItemsRepository(dbAccess);
            recetasRespository = new RecetasRepository(dbAccess);
        }

        public Item ObtenerItem(int id)
        {
            var item = itemsRespository.Obtener(id);
            item.Receta = recetasRespository.Consultar(id);

            return item;
        }

    }
}
