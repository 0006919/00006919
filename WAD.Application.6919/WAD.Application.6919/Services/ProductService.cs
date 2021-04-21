using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD.Application._6919.ViewModels;

namespace WAD.Application._6919.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _category_repository;

        public ProductService(IProductRepository repository, ICategoryRepository category_repository)
        {
            _repository = repository;
            _category_repository = category_repository;
        }

        public List<ProductViewModel> GetAll()
        {
            List<Product> list = _repository.GetAll();

            List<ProductViewModel> listvm = null;

            if (list != null && list.Count() > 0) {
                listvm = new List<ProductViewModel>();
                foreach (Product item in list)
                {
                    Category cy = _category_repository.GetAll().Single(x=> x.Id == item.CategoryId);
                    item.Category = cy;
                    ProductViewModel vm = Product2ProductViewModel(item);
                    listvm.Add(vm);
                }
            }

            return listvm;
        }

        public ProductViewModel GetById(Int32 Id)
        {
            Product product = _repository.GetById(Id);
            
            Category cy = _category_repository.GetAll().Single(x => x.Id == product.CategoryId);
            product.Category = cy;

            return Product2ProductViewModel(product);
        }

        public bool Create(ProductViewModel c) {
            return _repository.Create(ProductViewModel2Product(c));
        }

        public bool Update(ProductViewModel c)
        {
            return _repository.Update(ProductViewModel2Product(c));
        }

        public bool Delete(Int32 Id)
        {
            return _repository.Delete(Id);
        }

        ProductViewModel Product2ProductViewModel(Product m) {
            if (m == null)
                return null;
            return new ProductViewModel() {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                Price = m.Price,
                Category = Category2CategoryViewModel(m.Category)
            };
        }

        Product ProductViewModel2Product(ProductViewModel vm)
        {
            return new Product()
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                Price = vm.Price,
                Category = CategoryViewModel2Category(vm.Category)
            };
        }

        CategoryViewModel Category2CategoryViewModel(Category m)
        {
            if (m == null)
                return null;
            return new CategoryViewModel()
            {
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
