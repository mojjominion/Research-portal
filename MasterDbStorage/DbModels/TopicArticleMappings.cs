using MasterDbStorage.DbModels.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MasterDbStorage.DbModels
{
    class TopicArticleMappings : ICreation, IDeletable
    {
        public int Id { get; set; }
        [ForeignKey("ResearchTopic")]
        public long? ResearchTopicId { get; set; }
        [ForeignKey("Article")]
        public long? ArticleId { get; set; }
        public ResearchTopic ResearchTopic { get; set; }
        public Article Article{ get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
