using System;
using System.Collections.Generic;
using System.Text;

namespace PilotWorksAPI.Core.DataLayer
{
    public class PilotWorksEntityMapper : EntityMapper
    {
        public PilotWorksEntityMapper()
        {
            Mappings = new List<IEntityMap>()
            {
                new ProductMap() as IEntityMap
            };
        }
    }
}
