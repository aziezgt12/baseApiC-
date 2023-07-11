using Microsoft.AspNetCore.Mvc;
using spotApi.Models;
using spotApi.Repo;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace spotApi.Controllers
{
    [ApiController]
    [Route("spotApi/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IBaseRepository<Product> _productRepository;

        public ProductController(IBaseRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }


        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }






    

    //[HttpPost]
    //public IHttpActionResult AddProduct(Product product)
    //{
    //    _productRepository.Add(product);
    //    return Created("api/products/" + product.id, product);
    //}

    //[HttpPut]
    //public IHttpActionResult UpdateProduct(Product product)
    //{
    //    _productRepository.Update(product);
    //    return Ok(product);
    //}

    //[HttpDelete]
    //public IHttpActionResult DeleteProduct(int id)
    //{
    //    var product = _productRepository.GetById(id);
    //    if (product == null)
    //        return NotFound();

    //    _productRepository.Delete(product);
    //    return Ok();
    //}

}
