using MasterDbStorage.DbModels;
using MasterDbStorage.DbRespository;
using MasterDbStorage.MasterDbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDbStorage.Data.Services
{
    public class ArticleService : ServiceBase<Article>
    {
        public ArticleService(MasterDBContext masterDbContext) : base(masterDbContext)
        {
        }

    }
}
