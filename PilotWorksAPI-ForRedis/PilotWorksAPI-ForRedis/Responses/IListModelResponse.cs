using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PilotWorksAPI.Responses
{
    public interface IListModelResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }
}
