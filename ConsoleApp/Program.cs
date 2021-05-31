using System;
using System.Linq;
using BL.MaterialPrinterLab;
using EL.MaterialPrinterLab.Model;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=localhost;Initial Catalog=MaterialPrinterLab; Integrated Security=True;";
            var dataInicialManager = new DataInicialManager(connectionString);
            var itemManager = new ItemsManager(connectionString);
            var reportesManager = new ReportesManager(connectionString);

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Importar datos iniciales? Y / N");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                dataInicialManager.ImportarDatosIniciales();
                Console.WriteLine("\nDatos iniciales importados");
            }
            
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("Crear 150 impresoras? Y / N");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                dataInicialManager.CrearImpresoras(150);
                Console.WriteLine("Datos de impresoras insertados");
            }

            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("Consutar Item? 1: ColaFenix, 2: Manzana, 3: Potasio");
            var itemSeleccionado = new Item();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    itemSeleccionado = itemManager.ObtenerItemConReceta(400);
                    break;
                case ConsoleKey.D2:
                    itemSeleccionado = itemManager.ObtenerItemConReceta(356);
                    break;
                case ConsoleKey.D3:
                    itemSeleccionado = itemManager.ObtenerItemConReceta(370);
                    break;
            }
            if (itemSeleccionado.Id > 0)
            {
                Console.WriteLine($"\n{itemSeleccionado.Nombre}, t={itemSeleccionado.Tiempo}");
                itemSeleccionado.Receta.ForEach(i => { Console.Write($"- {i.InsumoItem.Nombre}, {i.Cantidad}\n"); });
            }

            //var itemSoloDebug = itemManager.ObtenerItemConRecetasCompletas(400);

            Console.WriteLine("\n---------------------------------");
            var reporteRecetas = reportesManager.GenerarReporteConsultaReceta(itemSeleccionado.Id, true);

            Console.WriteLine($"-- RECETA: {itemSeleccionado.Nombre}--");
            Console.WriteLine($"\n{("Item").PadRight(15)}|{("Insumo").PadRight(15)}|{"cNe".PadLeft(3)}|{"cEx".PadLeft(3)}|{"SeImp".PadLeft(5)}|{"cIm".PadLeft(3)}|{"Tmp".PadLeft(3)}|Impresora");
            reporteRecetas.ForEach(i => 
                {Console.WriteLine($"{i.NombreItem.PadRight(15)}|{i.NombreInsumo.PadRight(15)}|{i.CantidadNecesaria.ToString().PadLeft(3)}|{i.CantidadExistente.ToString().PadLeft(3)}|{i.SeImprime.ToString().PadLeft(5)}|{i.CantidadAImprimir.ToString().PadLeft(3)}|{i.Tiempo.ToString().PadLeft(3)}|{i.ImpresoraNombre.PadRight(15)}");});
            Console.WriteLine($"TIEMPO TOTAL 1 Impresora: {reporteRecetas.Where(rep => rep.SeImprime).Sum(rep => rep.Tiempo * rep.CantidadAImprimir)}");
            var impresorasAUsar = reporteRecetas.Where(rep => rep.SeImprime).GroupBy(rep => rep.ImpresoraId).Select(r => r.First()).ToList();
            var max = 0;
            foreach (var i in impresorasAUsar)
            {
                var suma = reporteRecetas.Where(r => r.ImpresoraId == i.ImpresoraId)
                    .Sum(rep => rep.Tiempo * rep.CantidadAImprimir);
                max = suma > max ? suma : max;
            }
            Console.WriteLine($"TIEMPO TOTAL Varias Impresoras: {max}");
        }

    }
}
