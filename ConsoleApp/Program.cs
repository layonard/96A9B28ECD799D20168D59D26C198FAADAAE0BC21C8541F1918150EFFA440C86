using System;
using BL.MaterialPrinterLab;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataInicialManager = new DataInicialManager("Data Source=localhost;Initial Catalog=MaterialPrinterLab; Integrated Security=True;");

            //dataInicialManager.ImportarDatosIniciales();
            dataInicialManager.CrearImpresoras(150);

            Console.WriteLine("Datos insertados");
        }

    }
}
