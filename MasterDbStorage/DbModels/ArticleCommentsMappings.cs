using MasterDbStorage.DbModels.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MasterDbStorage.DbModels
{
    public class ArticleCommentsMappings : ICreation, IDeletable
    {
        public int Id { get; set; }
        [ForeignKey("Comment")]
        public long? CommentId { get; set; }
        [ForeignKey("Article")]
        public long? ArticleId { get; set; }
        public Comment Comment { get; set; }
        public Article Article { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
