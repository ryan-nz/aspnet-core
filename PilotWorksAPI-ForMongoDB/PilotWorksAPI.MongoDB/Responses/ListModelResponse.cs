using System.Collections.Generic;

namespace PilotWorksAPI.MongoDB.Responses
{
    public class ListModelResponse<TModel> : IListModelResponse<TModel>
    {
        public IEnumerable<TModel> Model { get; set; }
        public string Message { get; set; }
        public bool HadError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
