namespace GameStore.CleanArch.Backend.Domain.Models
{
    public class OkResponseModel : BaseModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }
}
