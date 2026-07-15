using KnowledgeHubPortal.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace KnowledgeHubPortal.Data
{
    public class KnowledgeHubPortalDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost; port=5432; dbname=KnowledgeHubPortalA; user=postgres; password=kalki");
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
