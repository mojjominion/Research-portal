using MasterDbStorage.DbModels.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MasterDbStorage.DbModels
{
    [Table("AspNetUsers")]
    public class Researcher : IdentityUser, ICreation, IDeletable
    {
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
