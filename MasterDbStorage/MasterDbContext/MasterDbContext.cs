using MasterDbStorage.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDbStorage.MasterDbContext
{
    public class MasterDbContext : DbContext
    {
        public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options)
        {
        }
    }

}
