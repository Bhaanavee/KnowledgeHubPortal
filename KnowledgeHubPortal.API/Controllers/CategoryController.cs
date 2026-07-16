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
        [HttpGet]
        public IActionResult GetCategories()
        {
            // Fetch all the categories from the database
            ICategoryRepository categoryRepository = new CategoryRepository();
            var categories = categoryRepository.GetCategories();
            if (categories == null || categories.Count == 0)
            {
                return NotFound("No categories Found");
            }

            return Ok(categories);
        }
    }
}
