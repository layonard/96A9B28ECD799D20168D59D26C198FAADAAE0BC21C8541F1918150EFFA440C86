using System;
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
                    itemSeleccionado = itemManager.ObtenerItem(400);
                    break;
                case ConsoleKey.D2:
                    itemSeleccionado = itemManager.ObtenerItem(356);
                    break;
                case ConsoleKey.D3:
                    itemSeleccionado = itemManager.ObtenerItem(370);
                    break;
            }
            Console.WriteLine($"\n{itemSeleccionado.Nombre}, t={itemSeleccionado.Tiempo}");
            itemSeleccionado.Receta.ForEach(i => { Console.Write($"- {i.InsumoItem.Nombre}, {i.Cantidad}\n"); });

            

        }

    }
}
