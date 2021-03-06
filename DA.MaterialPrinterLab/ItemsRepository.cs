using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL.MaterialPrinterLab.Model;
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

        public List<Item> ObtenerTodo()
        {
            try
            {
                return _db.Items.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
                //return new List<Item>();
            }
        }
        public Item Obtener(int id)
        {
            try
            {
                return _db.Items.FirstOrDefault(i => i.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Item Obtener(string nombre)
        {
            try
            {
                return _db.Items.FirstOrDefault(i => i.Nombre == nombre);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int Contar()
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

        public List<Item> Insertar(List<Item> items)
        {
            try
            {
                _db.Items.AddRange(items);
                _db.SaveChanges();
                return items;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Item IncrementarStock(Item item, int cantidad)
        {
            try
            {
                _db.Items.FirstOrDefault(i => i.Id == item.Id).Stock+= cantidad;

                _db.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
