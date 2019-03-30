using MasterDbStorage.DbRespository;
using MasterDbStorage.DbRespository.Interfaces;
using MasterDbStorage.MasterDbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDbStorage.Data.Services
{
    public class ServiceBase<TEntity> where TEntity : class
    {
        private readonly Repository<TEntity> repository;

        public ServiceBase(MasterDBContext masterDbContext)
        {
            this.repository = new Repository<TEntity>(masterDbContext);
        }
    }
}
