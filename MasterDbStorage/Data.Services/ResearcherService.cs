using MasterDbStorage.DbModels;
using MasterDbStorage.DbRespository;
using MasterDbStorage.MasterDbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDbStorage.Data.Services
{
    public class ResearcherService : ServiceBase<Article>
    {
        public ResearcherService(MasterDBContext masterDbContext) : base(masterDbContext)
        {
        }

    }
}
