using KnowledgeHubPortal.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeHubPortal.Business.Interfaces
{
    public interface IArticleRepository
    {
        void SubmitArticle(Article article);
        List<Article> GetArticlesForReview();
        void ApproveArticle(List<int> articlesIds);
        void RejectArticle(List<int> articlesIds);
        List<Article> BrowseArticles(int categoryId);

    }
}