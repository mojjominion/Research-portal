using MasterDbStorage.DbModels;
using MasterDbStorage.DbRespository;
using MasterDbStorage.MasterDbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDbStorage.Data.Services
{
    public class CommentService : ServiceBase<Article>
    {
        public CommentService(MasterDBContext masterDbContext) : base(masterDbContext)
        {
        }

    }
}
