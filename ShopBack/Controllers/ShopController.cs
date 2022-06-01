using Microsoft.AspNetCore.Mvc;
using ShopBack.Interfaces.Repositories;
using ShopBack.Models;
using System.Collections.Generic;

namespace ShopBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ShopController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> Get()
        {
            var result = _productRepository.GetAll();

            return result;
        }

        [HttpPost(Name = "PostProduct")]
        public bool Post([FromQuery] string url, [FromQuery] string name)
        {
            var result = _productRepository.Create(new Product { ImageUrl = url, Name = name });
            _productRepository.Save();

            return result;
        }

        [HttpPut(Name = "PutProduct")]
        public bool Put([FromQuery] string newUrl, [FromQuery] string newName, [FromQuery] string oldUrl, [FromQuery] string oldName)
        {
            var result = _productRepository.Update(new Product { ImageUrl = oldUrl, Name = oldName }, new Product { ImageUrl = newUrl, Name = newName });
            _productRepository.Save();

            return result;
        }

        [HttpDelete(Name = "DeleteProduct")]
        public bool Delete([FromQuery] string url, [FromQuery] string name)
        {
            var result = _productRepository.Delete(new Product { ImageUrl = url, Name = name });
            _productRepository.Save();

            return result;
        }
    }
}
