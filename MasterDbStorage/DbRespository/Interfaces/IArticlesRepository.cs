using MasterDbStorage.DbModels;
using MasterDbStorage.DbRespository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDbStorage.DbRespository.Interfaces
{
    public interface IArticlesRepository : IRepository<Article>
    {
        IEnumerable<Article> GetByAuthor(string authorId);
        IEnumerable<Article> GetByUser(long userId);
        IEnumerable<Article> GetByTopic(int topicId);
    }
}
