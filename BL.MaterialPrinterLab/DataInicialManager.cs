﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.MaterialPrinterLab;
using EL.MaterialPrinterLab;
using EL.MaterialPrinterLab.Models;

namespace BL.MaterialPrinterLab
{
    public class DataInicialManager
    {
        private ItemsRepository itemsRespository;
        private ImpresorasRepository impresorasRepository;

        public DataInicialManager(string CadenaConexion)
        {
            var dbAccess = new MaterialPrinterContext(CadenaConexion);
            itemsRespository = new ItemsRepository(dbAccess);
            impresorasRepository = new ImpresorasRepository(dbAccess);
        }

        public void ImportarDatosIniciales()
        {
            if (itemsRespository.Contar() > 0) return;

            var listaItems = new List<Item>();
            var rutaArchivo = "C:\\3D Printer Datatable.csv";
            var lineas = System.IO.File.ReadAllLines(rutaArchivo);

            //Leer solo los items, sin insumos
            foreach (var linea in lineas)
            {
                var columnas = linea.Split(',');

                if (columnas[0] == "id") continue;

                var nuevoItem = new Item();
                var resultado = 0;
                nuevoItem.Nombre = columnas[1];
                nuevoItem.Tiempo = Int32.TryParse(columnas[12], out resultado) ? resultado : 0;
                nuevoItem.Stock = Int32.TryParse(columnas[13], out resultado) ? resultado : 0;
                nuevoItem.EsBase = columnas[14] == "V";
                nuevoItem.Receta = new List<Receta>();

                listaItems.Add((nuevoItem));
            }
            //Leer los insumos de la receta
            foreach (var linea in lineas)
            {
                var columnas = linea.Split(',');

                if (columnas[0] == "id") continue;

                //El csv solo contiene hasta 5 insumos por item
                for (int i = 1; i <= 5; i++)
                {
                    var nombreInsumo = columnas[i * 2];
                    var cantidadInsumo = columnas[i * 2 + 1];
                    if (!String.IsNullOrEmpty(nombreInsumo))
                    {
                        var resultado = 0;
                        var item = listaItems.FirstOrDefault(i => i.Nombre == columnas[1]);
                        var insumo = listaItems.FirstOrDefault(i => i.Nombre == nombreInsumo);

                        item.Receta.Add(
                            new Receta
                            {
                                Insumo = insumo,
                                Cantidad = Int32.TryParse(cantidadInsumo, out resultado) ? resultado : 0
                            });
                    }
                }
            }

            itemsRespository.Insertar(listaItems);
        }

        public void CrearImpresoras(int cantidadImpresoras)
        {
            var impresoras = new List<Impresora>();
            for (int i = 1; i <= cantidadImpresoras; i++)
            {
                impresoras.Add(new Impresora()
                {
                    Nombre = $"Impresora {i}",
                    Imprimiendo = false
                });
            }

            impresorasRepository.Insertar(impresoras);
        }
    }
}
