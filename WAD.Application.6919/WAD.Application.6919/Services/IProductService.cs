using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD.Application._6919.ViewModels;

namespace WAD.Application._6919.Services
{
    public interface IProductService
    {
        public List<ProductViewModel> GetAll();
        public ProductViewModel GetById(Int32 Id);
        public bool Create(ProductViewModel c);
        public bool Update(ProductViewModel c);
        public bool Delete(Int32 Id);
    }
}
