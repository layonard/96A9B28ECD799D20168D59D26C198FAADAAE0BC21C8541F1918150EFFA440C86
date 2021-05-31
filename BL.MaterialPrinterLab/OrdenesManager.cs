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
        private ItemsManager itemsManager;
        private ImpresorasRepository impresorasRepository;
        private SolicitudesRepository solicitudesRepository;
        private OrdenesRepository ordenesRepository;
        private readonly string _solicitante;

        public OrdenesManager(string CadenaConexion, string solicitante)
        {
            var dbAccess = new MaterialPrinterContext(CadenaConexion);
            itemsRespository = new ItemsRepository(dbAccess);
            itemsManager = new ItemsManager(CadenaConexion);
            impresorasRepository = new ImpresorasRepository(dbAccess);
            solicitudesRepository = new SolicitudesRepository(dbAccess);
            ordenesRepository = new OrdenesRepository(dbAccess);

            _solicitante = solicitante;
        }

        public List<OrdenImpresion> RealizarOrden(List<int> itemsId)
        {
            var listaOrdenImpresion = new List<OrdenImpresion>();
            var hoy = DateTime.Now;
            
            foreach (var itemId in itemsId)
            {
                var solicitud = new Solicitud();
                solicitud.Solicitante = _solicitante;
                solicitud.FechaSolicitud = hoy;
                solicitud = solicitudesRepository.Registrar(solicitud);

                var item = itemsManager.ObtenerItemConRecetasCompletas(itemId);

                listaOrdenImpresion.AddRange(RealizarOrden(item, 1, solicitud.Id));

                itemsRespository.IncrementarStock(item, 1);
            }

            listaOrdenImpresion = ordenesRepository.Registrar(listaOrdenImpresion);

            return listaOrdenImpresion;
        }

        public List<OrdenImpresion> RealizarOrden(Item item, int cantidadSolicitada, int solicitudId)
        {
            var listaOrdenImpresion = new List<OrdenImpresion>();
            var registroOrden = new OrdenImpresion();
            
            registroOrden.NumeroSolicitud = solicitudId;
            registroOrden.ItemId = item.Id;
            registroOrden.DuracionEstimada = item.Tiempo;
            registroOrden.Estado = EstadoOrden.Pendiente;
            listaOrdenImpresion.Add(registroOrden);

            if (item.EsBase) return listaOrdenImpresion;

            foreach (var insumo in item.Receta)
            {
                var diferenciaCantidad = insumo.InsumoItem.Stock - (cantidadSolicitada * insumo.Cantidad);
                if (diferenciaCantidad < 0)
                {
                    listaOrdenImpresion.AddRange(RealizarOrden(insumo.InsumoItem, Math.Abs(diferenciaCantidad), solicitudId));
                }
                else
                {
                    itemsRespository.IncrementarStock(insumo.InsumoItem, -cantidadSolicitada);
                }
            }

            return listaOrdenImpresion;
        }


    }
}
