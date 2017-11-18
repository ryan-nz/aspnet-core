using Microsoft.EntityFrameworkCore;

namespace PilotWorksAPI.Core.DataLayer
{
    public interface IEntityMap
    {
        void Map(ModelBuilder modelBuilder);
    }
}
