using KnowledgeHubPortal.Business.Entities;
using KnowledgeHubPortal.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeHubPortal.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private KnowledgeHubPortalDBContext db = new KnowledgeHubPortalDBContext();
        public void CreateCategory(Category category)
        {
            db.Category.Add(category);
            db.SaveChanges();

        }
        public List<Category> GetCategories()
        {
            return db.Category.ToList();
        }
    }
}
