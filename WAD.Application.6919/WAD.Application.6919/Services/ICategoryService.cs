using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD.Application._6919.ViewModels;

namespace WAD.Application._6919.Services
{
    public interface ICategoryService
    {
        public List<CategoryViewModel> GetAll();
        public CategoryViewModel GetById(Int32 Id);
        public bool Create(CategoryViewModel c);
        public bool Update(CategoryViewModel c);
        public bool Delete(Int32 Id);
    }
}
