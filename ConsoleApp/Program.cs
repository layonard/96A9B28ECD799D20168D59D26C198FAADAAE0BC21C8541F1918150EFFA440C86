using System;
using BL.MaterialPrinterLab;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var itemsManager = new ItemsManager("Data Source=localhost;Initial Catalog=MaterialPrinterLab; Integrated Security=True;");

            itemsManager.ImportarDatosIniciales();
        }

    }
}
