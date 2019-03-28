using MasterDbStorage.DbModels.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MasterDbStorage.DbModels
{
    public class ResearcherCommentsMappings : ICreation, IDeletable
    {
        public int Id { get; set; }
        [ForeignKey("Comment")]
        public long? CommentId { get; set; }
        [ForeignKey("Researcher")]
        public string ResearcherId { get; set; }
        public Comment Comment { get; set; }
        public Researcher Researcher { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
