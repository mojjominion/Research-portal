using System;
using System.Collections.Generic;
using System.Text;
using MasterDbStorage.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ResearchPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Researcher> Researcher { get; set; }
        public DbSet<Researcher> Researchers { get; set; }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ResearchTopic> ResearchTopics { get; set; }

        public DbSet<ArticleCommentsMappings> ArticleCommentsMappings { get; set; }
        public DbSet<ResearcherArticleMappings> ResearcherArticleMappings { get; set; }
        public DbSet<ResearcherCommentsMappings> ResearcherCommentsMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
