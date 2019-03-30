using MasterDbStorage.DbModels;
using MasterDbStorage.DbRespository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDbStorage.DbRespository.Interfaces
{
    public interface ITopicsRepository : IRepository<ResearchTopic>
    {
        IEnumerable<ResearchTopic> GetByResearcherId(string researcherGuid);
    }
}
