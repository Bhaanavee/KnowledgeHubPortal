using KnowledgeHubPortal.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeHubPortal.Business.Interfaces
{
    public interface IArticleRepository
    {
        // submit, approve, 
        void SubmitArticle(Article article);
        List<Article> GetArticleForReview();
        void ApproveArticles(List<int> Articleids);
        void RejectArticles(List<int> Articleids);
        List<Article> BrowseArticles(int categoryId);
    }
}
