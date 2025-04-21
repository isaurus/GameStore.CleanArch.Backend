namespace GameStore.CleanArch.Backend.API.Models
{
    public class GameResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string ReleaseYear { get; set; } = string.Empty;
        public string FormattedPrice { get; set; } = string.Empty;
    }
}
