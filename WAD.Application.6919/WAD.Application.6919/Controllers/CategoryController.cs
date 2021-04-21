using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WAD.Application._6919.Services;
using WAD.Application._6919.ViewModels;

namespace WAD.Application._6919.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        // GET: api/category/getall
        [HttpGet]
        public IEnumerable<CategoryViewModel> GetAll()
        {
            return _service.GetAll();
        }

        // GET api/category/get/1
        [HttpGet("{Id}")]
        public CategoryViewModel Get(Int32 Id)
        {
            return _service.GetById(Id);
        }

        // POST api/category/create
        [HttpPost]
        public bool Create([FromBody] CategoryViewModel vm)
        {
            return _service.Create(vm);
        }

        // POST api/category/update
        [HttpPost]
        public bool Update([FromBody] CategoryViewModel vm)
        {
            return _service.Update(vm);
        }

        // GET api/category/delete/1
        [HttpGet("{Id}")]
        public bool Delete(Int32 Id)
        {
            return _service.Delete(Id);
        }

    }
}
