using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        public Product GetById(Int32 Id);
        public bool Create(Product c);
        public bool Update(Product c);
        public bool Delete(Int32 Id);
    }
}
