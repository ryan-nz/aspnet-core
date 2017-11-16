using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksAPI.Responses
{
    public class ListModelResponse<TModel> : IListModelResponse<TModel>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<TModel> Model { get; set; }
        public string Message { get; set; }
        public bool HadError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
