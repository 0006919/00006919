using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SalesDbContext _db;

        public CategoryRepository(SalesDbContext db)
        {
            _db = db;
        }

        public List<Category> GetAll()
        {
            return _db.Categories.ToList();
        }

        public Category GetById(Int32 Id)
        {
            return _db.Categories.Where(x => x.Id == Id).FirstOrDefault();
        }

        public bool Create(Category c)
        {
            try
            {                
                _db.Categories.Add(c);
                _db.SaveChanges();
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public bool Update(Category c)
        {
            var existing = GetAll().FirstOrDefault(x => x.Id == c.Id);
            if (existing != null)
            {
                try
                {
                    existing.Name = c.Name;
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
                _db.Categories.Remove(GetAll().First(x => x.Id == Id));
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
