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
    public class ArticleRepository : Repository<Article>, IArticlesRepository
    {

        public MasterDBContext _masterDB
        {
            get
            {
                return dbContext as MasterDBContext;
            }
        }
        public ArticleRepository(MasterDBContext masterDBContext) : base(masterDBContext)
        {
        }

        public IEnumerable<Article> GetByAuthor(string authorGuid)
        {
            return _masterDB.Articles.Where(a => a.Author.Id == authorGuid);
        }

        public IEnumerable<Article> GetByTopic(int topicId)
        {
            return _masterDB.Articles.Where(m => m.ResearchTopic.Id == topicId);
        }

        public IEnumerable<Article> GetByUser(long userId)
        {
            return _masterDB.Articles.Where(m => m.ResearchTopic.Id == userId);
        }
    }
}
