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
    public class ReportesManager
    {
        private ItemsRepository itemsRespository;
        private ItemsManager itemsManager;
        private RecetasRepository recetasRespository;

        public ReportesManager(string CadenaConexion)
        {
            var dbAccess = new MaterialPrinterContext(CadenaConexion);
            itemsRespository = new ItemsRepository(dbAccess);
            itemsManager = new ItemsManager(CadenaConexion);
            recetasRespository = new RecetasRepository(dbAccess);
        }

        public List<ReporteVerificarImpresionItem> GenerarReporteConsultaReceta(int id)
        {
            var listaReceta = new List<ReporteVerificarImpresionItem>();

            var item = itemsManager.ObtenerItemConRecetasCompletas(id);
            var registroReporte = new ReporteVerificarImpresionItem();
            registroReporte.ItemId = id;
            registroReporte.NombreItem = item.Nombre;
            registroReporte.NombreInsumo = "";
            registroReporte.CantidadNecesaria = 1;
            registroReporte.SeImprime = true;
            registroReporte.CantidadAImprimir = 1;
            registroReporte.Tiempo = item.Tiempo;
            listaReceta.Add(registroReporte);
            listaReceta.AddRange(ConsultarReceta(item.Receta));

            return listaReceta;
        }

        private List<ReporteVerificarImpresionItem> ConsultarReceta(List<Insumo> receta)
        {
            var listaReceta = new List<ReporteVerificarImpresionItem>();

            foreach (var insumo in receta)
            {
                var registroReporte = new ReporteVerificarImpresionItem();
                var diferenciaCantidad = insumo.InsumoItem.Stock - insumo.Cantidad;

                registroReporte.ItemId = insumo.ItemId;
                registroReporte.NombreItem = insumo.Item.Nombre;
                registroReporte.InsumoId = insumo.InsumoId;
                registroReporte.NombreInsumo = insumo.InsumoItem.Nombre;
                registroReporte.CantidadNecesaria = insumo.Cantidad;
                registroReporte.CantidadExistente = insumo.InsumoItem.Stock;
                registroReporte.SeImprime = diferenciaCantidad < 0;
                registroReporte.CantidadAImprimir = registroReporte.SeImprime ? Math.Abs(diferenciaCantidad) : 0;
                registroReporte.Tiempo = insumo.InsumoItem.Tiempo;
                listaReceta.Add(registroReporte);

                insumo.InsumoItem.Stock -= insumo.Cantidad;

                if (registroReporte.SeImprime && !insumo.InsumoItem.EsBase)
                {
                    listaReceta.AddRange(ConsultarReceta(insumo.InsumoItem.Receta));
                }
            }

            return listaReceta;
        }
    }
}
