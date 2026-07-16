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
            optionsBuilder.UseNpgsql("Host=localhost; Port=5432; database=KnowledgeHubPortal; username=postgres; password=kalki");
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
