using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD.Application._6919.ViewModels;

namespace WAD.Application._6919.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public List<CategoryViewModel> GetAll()
        {
            List<Category> list = _repository.GetAll();

            List<CategoryViewModel> listvm = null;

            if (list != null && list.Count() > 0) {
                listvm = new List<CategoryViewModel>();
                foreach (Category item in list)
                {
                    CategoryViewModel vm = Category2CategoryViewModel(item);
                    listvm.Add(vm);
                }
            }

            return listvm;
        }

        public CategoryViewModel GetById(Int32 Id)
        {
            Category category = _repository.GetById(Id);
            return Category2CategoryViewModel(category);
        }

        public bool Create(CategoryViewModel c) {
            return _repository.Create(CategoryViewModel2Category(c));
        }

        public bool Update(CategoryViewModel c)
        {
            return _repository.Update(CategoryViewModel2Category(c));
        }

        public bool Delete(Int32 Id)
        {
            return _repository.Delete(Id);
        }

        CategoryViewModel Category2CategoryViewModel(Category m) {
            if (m == null)
                return null;
            return new CategoryViewModel() {
                Id = m.Id,
                Name = m.Name
            };
        }

        Category CategoryViewModel2Category(CategoryViewModel vm)
        {
            return new Category()
            {
                Id = vm.Id,
                Name = vm.Name
            };
        }


    }
}
