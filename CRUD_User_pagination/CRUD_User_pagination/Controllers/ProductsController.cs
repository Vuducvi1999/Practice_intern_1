using Domain.Dtos.User;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CRUD_User_pagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _services;

        public ProductsController(IProductServices services)
        {
            _services = services;
        }
        // GET: api/<UsersController>
        [HttpGet]
        [EnableCors]
        public IActionResult Get()
        {
            try
            {
                var allProducts = _services.GetAll();
                return Ok(allProducts);
            }
            catch
            {
                
                throw;
            }
        }


        // Get pagination
        [HttpGet("page/{index}"), EnableCors]
        public IActionResult GetPaging(int index)
        {
            try
            {
                var result = _services.GetPage(index);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

            // GET api/<UsersController>/5
            [HttpGet("{id}"), EnableCors]
        public IActionResult Get(Guid id)
        {
            try
            {
                var product = _services.GetById(id);
                return Ok(product);
            }
            catch
            {
                throw;
            }
        }

        // POST api/<UsersController>
        [HttpPost, EnableCors]
        public IActionResult Post([FromForm] ProductEntity newProduct)
        {
            try
            {
                _services.Create(newProduct);
                return Ok();
            }
            catch
            {
                throw;
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}"), EnableCors]
        public IActionResult Put(Guid id, [FromForm] PutProduct updateProduct)
        {
            try
            {
                _services.UpdatePut(id, updateProduct);
                return Ok();
            }
            catch
            {
                throw;
            }
        }

        [HttpPatch("{id}"), EnableCors]
        public IActionResult Patch(Guid id, [FromForm] PatchProduct updateProduct)
        {
            try
            {
                _services.UpdatePatch(id, updateProduct);
                return Ok();
            }
            catch
            {
                throw;
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}"), EnableCors]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _services.Delete(id);
                return Ok();
            }
            catch
            {
                throw;
            }
        }
    }
}
