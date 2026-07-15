using KnowledgeHubPortal.Business.Entities;
using KnowledgeHubPortal.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeHubPortal.Data
{
    public class ArticlesRepository : IArticleRepository
    {
        private KnowledgeHubPortalDBContext db = new KnowledgeHubPortalDBContext();
        public void ApproveArticles(List<int> Articleids)
        {
            foreach (int Articleid in Articleids)
            {
                Article article = db.Articles.FirstOrDefault(a => a.ArticleID == Articleid);
                article.isApproved = true;
            }
        }

        public List<Article> BrowseArticles(int categoryId)
        {
            if (db.Articles.Any(a => a.CategoryID == categoryId && a.isApproved && !a.IsDeleted))
            {
                return db.Articles.Where(a => a.CategoryID == categoryId && a.isApproved && !a.IsDeleted).ToList();
            }
            else
            {
                return new List<Article>();
            }

        }

        public List<Article> GetArticleForReview()
        {
           return db.Articles.Where(a => !a.isApproved && !a.IsDeleted).ToList();

        }

        public void RejectArticles(List<int> Articleids)
        {
            foreach (int Articleid in Articleids)
            {
                Article article = db.Articles.FirstOrDefault(a => a.ArticleID == Articleid);
                article.isApproved = false;
            }
        }

        public void SubmitArticle(Article Articleids)
        {
            Article a = db.Articles.FirstOrDefault(a => a.ArticleID == Articleids.ArticleID);
            db.Articles.Add(a);
            db.SaveChanges();
        }
    }
}
