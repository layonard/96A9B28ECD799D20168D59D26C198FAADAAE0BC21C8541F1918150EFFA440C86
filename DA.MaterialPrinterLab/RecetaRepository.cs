using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL.MaterialPrinterLab.Model;

namespace DA.MaterialPrinterLab
{
    public class RecetaRepository
    {
        private readonly MaterialPrinterContext _db;

        public RecetaRepository(MaterialPrinterContext db)
        {
            _db = db;
        }

        public void Insertar(List<Insumo> receta)
        {
            try
            {
                _db.Recetas.AddRange(receta);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
