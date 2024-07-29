namespace BoletoBus.Common
{
    public class ServiceResult<TModel>
    {
        public ServiceResult()
        {
            this.Success = true;
        }

        public bool Success { get; set; }
        public string? Message { get; set; }
        public TModel? Data { get; set; }
    }
}
