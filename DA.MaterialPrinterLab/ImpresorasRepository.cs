using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL.MaterialPrinterLab.Models;

namespace DA.MaterialPrinterLab
{
    public class ImpresorasRepository
    {
        private readonly MaterialPrinterContext _db;

        public ImpresorasRepository(MaterialPrinterContext db)
        {
            _db = db;
        }

        public List<Impresora> ObtenerTodo()
        {
            try
            {
                return _db.Impresoras
                    .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Impresora Obtener(int id)
        {
            try
            {
                return _db.Impresoras
                    .FirstOrDefault(i => i.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insertar(Impresora impresora)
        {
            try
            {
                _db.Impresoras.Add(impresora);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insertar(List<Impresora> impresoras)
        {
            try
            {
                _db.Impresoras.AddRange(impresoras);
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
