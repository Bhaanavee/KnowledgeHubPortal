using KnowledgeHubPortal.Business.Entities;
using KnowledgeHubPortal.Business.Interfaces;
using KnowledgeHubPortal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        // get all categories
        [HttpGet]
        public IActionResult GetCategories()
        {
            // fetch all categories from the database/repository    
            ICategoryRepository categoryRepository = new CategoryRepository();
            var categories = categoryRepository.GetCategories();
            if (categories != null)
            {
                return Ok(categories);
            }
            else { return NotFound("No categories found."); }
            
        }

        // create a new category
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            // create a new category in the database/repository
            ICategoryRepository categoryRepository = new CategoryRepository();
            categoryRepository.CreateCategory(category);
            return Created($"/api/category/{category.CategoryID}", category);
        }

    }
}