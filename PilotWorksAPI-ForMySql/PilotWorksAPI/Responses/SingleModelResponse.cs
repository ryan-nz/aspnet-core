namespace PilotWorksAPI.Responses
{
    public class SingleModelResponse<TModel> : ISingleModelResponse<TModel>
    {
        public TModel Model { get; set; }
        public string Message { get; set; }
        public bool HadError { get; set; }
        public string ErrorMessage { get; set; }
    }

}