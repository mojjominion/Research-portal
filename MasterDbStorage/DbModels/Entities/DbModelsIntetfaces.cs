using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDbStorage.DbModels.Entities
{
    public interface IDbModelsIntetfaces
    {
    }
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
    }
    public interface ICreation
    {
        DateTime CreatedAt { get; set; }
        DateTime LastUpdated { get; set; }
    }
}
