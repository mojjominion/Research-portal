using MasterDbStorage.DbModels.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MasterDbStorage.DbModels
{
    public class ResearcherArticleMappings : ICreation, IDeletable
    {
        public int Id { get; set; }
        [ForeignKey("Researcher")]
        public string ResearcherId { get; set; }
        [ForeignKey("Article")]
        public long? ArticleId { get; set; }
        public Article Article { get; set; }
        public Researcher Researcher { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
