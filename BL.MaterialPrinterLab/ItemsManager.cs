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

        public Item ObtenerItemConReceta(int id)
        {
            var item = itemsRespository.Obtener(id);
            item.Receta = recetasRespository.Consultar(id);

            return item;
        }

        public Item ObtenerItemConRecetasCompletas(int id)
        {
            var item = itemsRespository.Obtener(id);
            item.Receta = recetasRespository.Consultar(id);

            foreach (var insumo in item.Receta)
            {
                if (insumo.InsumoItem.EsBase)
                {
                    continue;
                }

                insumo.InsumoItem = ObtenerItemConRecetasCompletas(insumo.InsumoId);
            }

            return item;
        }

    }
}
