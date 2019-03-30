using MasterDbStorage.DbModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDbStorage.DbModels
{
    public class BaseClass : ICreation, IDeletable
    {
        public long Id { get; set; }
        public string AuthorId { get; set; }
        public Researcher Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
