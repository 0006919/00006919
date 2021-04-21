using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SalesDbContext _db;

        public ProductRepository(SalesDbContext db)
        {
            _db = db;
        }

        public List<Product> GetAll()
        {
            return _db.Products.ToList();
        }

        public Product GetById(Int32 Id)
        {
            return _db.Products.Where(x => x.Id == Id).FirstOrDefault();
        }

        public bool Create(Product p)
        {
            try
            {
                Category c = _db.Categories.Single(c => c.Id == p.Category.Id);

                p.Category = c;
                _db.Products.Add(p);

                _db.SaveChanges();
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public bool Update(Product p)
        {
            var existing = GetAll().FirstOrDefault(x => x.Id == p.Id);
            if (existing != null)
            {
                try
                {
                    existing.Name = p.Name;
                    existing.Description = p.Description;
                    existing.Price = p.Price;

                    Category cat = _db.Categories.Single(c => c.Id == p.Category.Id);

                    existing.Category = cat;

                    _db.SaveChanges();
                    
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            return false;
        }

        public bool Delete(Int32 Id)
        {
            try
            {
                _db.Products.Remove(GetAll().First(x => x.Id == Id));
                _db.SaveChanges();
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return false;
        }

    }
}
