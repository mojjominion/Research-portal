using MasterDbStorage.DbModels;
using MasterDbStorage.DbRespository;
using MasterDbStorage.MasterDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterDbStorage.Data.Services
{
    public class ArticleService : ServiceBase<Article>
    {
        private readonly Repository<Article> _articleRepository;

        public ArticleService(MasterDBContext masterDbContext) : base(masterDbContext)
        {
            this._articleRepository = repository;
        }
        
        public IEnumerable<Article> GetAllArticles()
        {
            return _articleRepository.GetAll().ToList();
        }
    }
}
