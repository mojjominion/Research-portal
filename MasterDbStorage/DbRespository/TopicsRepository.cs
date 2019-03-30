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
    public class TopicsRepository : Repository<ResearchTopic>, ITopicsRepository
    {
        public TopicsRepository(DbContext masterDBContext) : base(masterDBContext)
        {
        }

        public MasterDBContext _masterDB
        {
            get
            {
                return dbContext as MasterDBContext;
            }
        }

        public IEnumerable<ResearchTopic> GetByResearcherId(string researcherGuid)
        {
            return _masterDB.ResearchTopics.Where(t => t.Author.Id == researcherGuid).ToList();
        }
    }
}
