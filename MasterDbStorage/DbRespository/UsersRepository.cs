using MasterDbStorage.DbModels;
using MasterDbStorage.DbRespository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MasterDbStorage.MasterDbContext;
using System.Linq;

namespace MasterDbStorage.DbRespository
{
    public class UsersRepository : Repository<Researcher>, IUsersRepository
    {
        public UsersRepository(DbContext masterDBContext) : base(masterDBContext)
        {
        }

        public MasterDBContext _masterDB
        {
            get
            {
                return dbContext as MasterDBContext;
            }
        }

        public IEnumerable<Researcher> GetByTopic(int topicId)
        {
            throw new NotImplementedException();
        }
    }
}
