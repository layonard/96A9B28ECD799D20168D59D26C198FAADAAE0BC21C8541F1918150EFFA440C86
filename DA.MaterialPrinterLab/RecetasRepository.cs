using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL.MaterialPrinterLab.Model;
using Microsoft.EntityFrameworkCore;

namespace DA.MaterialPrinterLab
{
    public class RecetasRepository
    {
        private readonly MaterialPrinterContext _db;

        public RecetasRepository(MaterialPrinterContext db)
        {
            _db = db;
        }

        public List<Insumo> Consultar(int itemId)
        {
            try
            {
                return _db.Recetas
                    .Where(i => i.ItemId == itemId)
                    .Include(i => i.InsumoItem)
                    .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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
