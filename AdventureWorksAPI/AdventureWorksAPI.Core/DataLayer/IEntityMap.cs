using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorksAPI.Core.DataLayer
{
    interface IEntityMap
    {
        void Map(ModelBuilder modelBuilder);
    }
}
