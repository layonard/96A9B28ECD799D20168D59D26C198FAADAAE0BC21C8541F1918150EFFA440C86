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
        private ImpresorasManager impresorasManager;
        private RecetasRepository recetasRespository;

        public ReportesManager(string CadenaConexion)
        {
            var dbAccess = new MaterialPrinterContext(CadenaConexion);
            itemsRespository = new ItemsRepository(dbAccess);
            itemsManager = new ItemsManager(CadenaConexion);
            impresorasManager = new ImpresorasManager(CadenaConexion);
            recetasRespository = new RecetasRepository(dbAccess);
        }

        public List<ReporteVerificarImpresionItem> GenerarReporteConsultaReceta(int id, bool usarVariasIMpresoras = false)
        {
            var listaReceta = new List<ReporteVerificarImpresionItem>();
            var listaImpresorasLibres = impresorasManager.ObtenerImpresorasLibres();
            var impresora = listaImpresorasLibres.FirstOrDefault();

            var item = itemsManager.ObtenerItemConRecetasCompletas(id);
            var registroReporte = new ReporteVerificarImpresionItem();
            registroReporte.ItemId = id;
            registroReporte.NombreItem = item.Nombre;
            registroReporte.NombreInsumo = "";
            registroReporte.CantidadNecesaria = 1;
            registroReporte.SeImprime = true;
            registroReporte.CantidadAImprimir = 1;
            registroReporte.Tiempo = item.Tiempo;
            if (impresora != null)
            {
                registroReporte.ImpresoraId = impresora.Id;
                registroReporte.ImpresoraNombre = impresora.Nombre;
                listaImpresorasLibres.Remove(impresora);
            }
            else
            {
                registroReporte.ImpresoraNombre = "(Impresoras no disponibles)";
            }
            
            listaReceta.Add(registroReporte);

            if (usarVariasIMpresoras)
            {
                listaReceta.AddRange(ConsultarReceta(item.Receta, 1, usarVariasIMpresoras, impresora, listaImpresorasLibres));
            }
            else
            {
                listaReceta.AddRange(ConsultarReceta(item.Receta,1, usarVariasIMpresoras, impresora));
            }
            
            return listaReceta;
        }

        private List<ReporteVerificarImpresionItem> ConsultarReceta(List<Insumo> receta, int cantidadFaltante, bool usarVariasImpresoras, Impresora impresora, List<Impresora> impresoras = null)
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
                registroReporte.CantidadNecesaria = insumo.Cantidad * cantidadFaltante;
                registroReporte.CantidadExistente = insumo.InsumoItem.Stock;
                registroReporte.SeImprime = diferenciaCantidad < 0;
                registroReporte.CantidadAImprimir = registroReporte.SeImprime ? Math.Abs(diferenciaCantidad) : 0;
                registroReporte.Tiempo = insumo.InsumoItem.Tiempo;
                if (registroReporte.SeImprime)
                {
                    if (usarVariasImpresoras && impresoras.Any())
                    {
                        var nuevaImpresora = impresoras.FirstOrDefault();
                        registroReporte.ImpresoraId = nuevaImpresora.Id;
                        registroReporte.ImpresoraNombre = nuevaImpresora.Nombre;
                        impresoras.Remove(nuevaImpresora);
                    }
                    else
                    {
                        if (impresora != null)
                        {
                            registroReporte.ImpresoraId = impresora.Id;
                            registroReporte.ImpresoraNombre = impresora.Nombre;
                        }
                        else
                        {
                            registroReporte.ImpresoraNombre = "(Impresoras no disponibles)";
                        }
                    }
                }
                else
                {
                    registroReporte.ImpresoraNombre = "";
                }
                
                
                listaReceta.Add(registroReporte);

                insumo.InsumoItem.Stock -= insumo.Cantidad;

                if (registroReporte.SeImprime && !insumo.InsumoItem.EsBase)
                {
                    listaReceta.AddRange(ConsultarReceta(insumo.InsumoItem.Receta, registroReporte.CantidadAImprimir, usarVariasImpresoras, impresora, impresoras));
                }
            }

            return listaReceta;
        }
    }
}
