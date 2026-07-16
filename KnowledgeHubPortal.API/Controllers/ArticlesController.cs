using KnowledgeHubPortal.Business.DTO;
using KnowledgeHubPortal.Business.Entities;
using KnowledgeHubPortal.Business.Interfaces;
using KnowledgeHubPortal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private IArticleRepository articlesRepository;
        public ArticlesController(IArticleRepository repo) // DI
        {
            this.articlesRepository = repo;
        }

        // submit article endpoint
        [HttpPost]
        [Route("submit")]
        public IActionResult SubmitArticle(ArticleSubmitDTO articleDto)
        {
            Article article = new Article // Use AutoMapper or manual mapping to convert DTO to entity
            {
                Title = articleDto.Title,
                ArticleURL = articleDto.ArticleUrl,
                Description = articleDto.Description,
                CategoryID = articleDto.CategoryID,
                isApproved = false, // default to false
                PostedBy = "Anonymous", // default to anonymous - replace with logged-in user info if available
                DateCreated = DateTime.UtcNow,
                IsDeleted = false // default to false
            };

            // Call the repository to submit the article
            articlesRepository.SubmitArticle(article);
            return CreatedAtAction(nameof(SubmitArticle), new { id = article.ArticleID }, article);
            // 201+Location+data
        }

        // get articles for review endpoint
        [HttpGet]
        [Route("review")]
        public IActionResult GetArticlesForReview()
        {
            var articles = articlesRepository.GetArticlesForReview();
            if (articles == null)
            {
                return NotFound("No articles found for review.");
            }
            return Ok(articles);
        }

        // approve articles endpoint
        [HttpPost]
        [Route("approve")]
        public IActionResult ApproveArticles(List<int> articlesIds)
        {
            articlesRepository.ApproveArticle(articlesIds);
            return Ok("Articles approved successfully.");
        }

        // reject articles endpoint
        [HttpPost]
        [Route("reject")]
        public IActionResult RejectArticles(List<int> articlesIds)
        {
            articlesRepository.RejectArticle(articlesIds);
            return Ok("Articles rejected successfully.");
        }

        // browse articles endpoint
        [HttpGet]
        [Route("browse")]
        public IActionResult BrowseArticles(int categoryId)
        {
            var articles = articlesRepository.BrowseArticles(categoryId);
            if (articles == null)
            {
                return NotFound("No articles found for the specified category.");
            }
            return Ok(articles);
        }
    }
}