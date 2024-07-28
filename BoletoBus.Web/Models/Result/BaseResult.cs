namespace BoletoBus.Web.Models.Result
{
    public class BaseResult<TModel>
    {
        public bool success { get; set; }
        public string? message { get; set; }

        public TModel? data { get; set; }
    }
}
