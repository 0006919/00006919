using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WAD.Application._6919.Services;
using WAD.Application._6919.ViewModels;

namespace WAD.Application._6919.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        // GET: api/product/getall
        [HttpGet]
        public IEnumerable<ProductViewModel> GetAll()
        {
            return _service.GetAll();
        }

        // GET api/product/get/1
        [HttpGet("{Id}")]
        public ProductViewModel Get(Int32 Id)
        {
            return _service.GetById(Id);
        }

        // POST api/product/create
        [HttpPost]
        public bool Create([FromBody] ProductViewModel vm)
        {
            return _service.Create(vm);
        }

        // POST api/product/update
        [HttpPost]
        public bool Update([FromBody] ProductViewModel vm)
        {
            return _service.Update(vm);
        }

        // GET api/product/delete/1
        [HttpGet("{Id}")]
        public bool Delete(Int32 Id)
        {
            return _service.Delete(Id);
        }
    }
}
