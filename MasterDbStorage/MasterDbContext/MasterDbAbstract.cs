using JetBrains.Annotations;
using MasterDbStorage.DbModels.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterDbStorage.MasterDbContext
{
    public abstract class MasterDbAbstract : IdentityDbContext
    {
        protected MasterDbAbstract(DbContextOptions options) : base(options)
        {
        }

        private void SetLastUpdated(IEnumerable<EntityEntry<ICreation>> changedEntities)
        {
            var now = DateTime.UtcNow;
            foreach (var item in changedEntities)
            {
                item.Entity.LastUpdated = now;
            }
        }
        public void PrepareDataForInsertion(List<ICreation> newDeviceEntities)
        {
            var now = DateTime.UtcNow;
            foreach (var item in newDeviceEntities)
            {
                item.CreatedAt = now;
            }
        }

        public override int SaveChanges()
        {
            var updatedEntities = ChangeTracker.Entries<ICreation>()
               .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
            SetLastUpdated(updatedEntities);

            var newEntities = ChangeTracker.Entries<ICreation>()
                .Where(e => e.State == EntityState.Added).Select(e => e.Entity).ToList();
            PrepareDataForInsertion(newEntities);
            return base.SaveChanges();
        }
    }
}
