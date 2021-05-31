using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL.MaterialPrinterLab.Model;

namespace DA.MaterialPrinterLab
{
    public class SolicitudesRepository
    {
        private readonly MaterialPrinterContext _db;

        public SolicitudesRepository(MaterialPrinterContext db)
        {
            _db = db;
        }

        public Solicitud Obtener(int id)
        {
            try
            {
                return _db.Solicitudes.FirstOrDefault(s => s.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public Solicitud Registrar(Solicitud solicitud)
        {
            try
            {
                _db.Solicitudes.Add(solicitud);
                _db.SaveChanges();
                return solicitud;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
