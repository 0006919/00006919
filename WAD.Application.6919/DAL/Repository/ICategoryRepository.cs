using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        public Category GetById(Int32 Id);
        public bool Create(Category c);
        public bool Update(Category c);
        public bool Delete(Int32 Id);
    }
}
