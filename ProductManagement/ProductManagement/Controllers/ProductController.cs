using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProductManagementAdapters.Entities;
using ProductManagementBusinessLibrary.Services;
using ProductManagementBusinessLibrary.Services.Contracts;

namespace ProductManagement.Controllers
{

    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        [Route("/AddProduct")]
        
        public async Task<IActionResult> AddProducts([FromBody]Product product)
        {
            
            try
            {
                
               await _productService.AddProduct(product);
                return Ok("Product Added Successfully");
               
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/GetProducts")]
        public IActionResult GetProducts()
        {
            IEnumerable<Product> products = _productService.GetAllProducts(); 
            return Ok(products);
        }

        [HttpDelete]
        [Route("/DeleteProduct/{ID}")]
        public IActionResult DeleteProduct([FromRoute]Guid ID)
        {
            try
            {
                
                    _productService.DeleteProduct(ID);
                    return Ok("Product Deleted Successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("/UpdateProduct/{ID}")]
        public IActionResult UpdateProduct([FromRoute]Guid ID, [FromBody]Product product)
        {
            try
            {

                _productService.UpdateProduct(ID,product);
                return Ok("Product Updated Successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
