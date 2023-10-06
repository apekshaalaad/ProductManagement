using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAdapters.Entities;
using ProductManagementBusinessLibrary.Services.Contracts;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        [Route("/AddCategory")]

        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {

            try
            {

                await _categoryService.AddCategory(category);
                return Ok("Category Added Successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/GetCategories")]
        public IActionResult GetCategories()
        {
            IEnumerable<Category> categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpDelete]
        [Route("/DeleteCategory/{ID}")]
        public IActionResult DeleteCategory([FromRoute] Guid ID)
        {
            try
            {

                _categoryService.DeleteCategory(ID);
                return Ok("Category Deleted Successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("/UpdateCategory/{ID}")]
        public IActionResult UpdateProduct([FromRoute] Guid ID, [FromBody] Category category)
        {
            try
            {

                _categoryService.UpdateCategory(ID, category);
                return Ok("Category Updated Successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
