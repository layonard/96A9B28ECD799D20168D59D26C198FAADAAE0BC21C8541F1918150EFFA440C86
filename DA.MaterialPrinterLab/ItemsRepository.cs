using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL.MaterialPrinterLab.Models;
using Microsoft.EntityFrameworkCore;

namespace DA.MaterialPrinterLab
{
    public class ItemsRepository
    {
        private readonly MaterialPrinterContext _db;

        public ItemsRepository(MaterialPrinterContext db)
        {
            _db = db;
        }

        public List<Item> ObtenerItems()
        {
            try
            {
                return _db.Items
                    .Include(i => i.Receta)
                    .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
                //return new List<Item>();
            }
        }
        public Item ObtenerItem(int id)
        {
            try
            {
                return _db.Items
                    .Where(i => i.Id == id)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Item ObtenerItem(string nombre)
        {
            try
            {
                return _db.Items
                    .Where(i => i.Nombre == nombre)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int ContarItems()
        {
            try
            {
                return _db.Items.Count();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insertar(Item item)
        {
            try
            {
                _db.Items.Add(item);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insertar(List<Item> items)
        {
            try
            {
                _db.Items.AddRange(items);
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
