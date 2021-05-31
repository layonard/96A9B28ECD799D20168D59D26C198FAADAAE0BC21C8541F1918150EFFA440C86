using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL.MaterialPrinterLab.Model;

namespace DA.MaterialPrinterLab
{
    public class OrdenesRepository
    {
        private readonly MaterialPrinterContext _db;

        public OrdenesRepository(MaterialPrinterContext db)
        {
            _db = db;
        }

        public OrdenImpresion Registrar(OrdenImpresion orden)
        {
            try
            {
                _db.Ordenes.Add(orden);
                _db.SaveChanges();
                return orden;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<OrdenImpresion> Registrar(List<OrdenImpresion> ordenes)
        {
            try
            {
                _db.Ordenes.AddRange(ordenes);
                _db.SaveChanges();
                return ordenes;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
