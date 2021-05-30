using System;
using BL.MaterialPrinterLab;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataInicialManager = new DataInicialManager("Data Source=localhost;Initial Catalog=MaterialPrinterLab; Integrated Security=True;");

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

                dataInicialManager.CrearImpresoras(150);

            Console.WriteLine("Datos insertados");
        }

    }
}
