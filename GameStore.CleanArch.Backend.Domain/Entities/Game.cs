namespace GameStore.CleanArch.Backend.Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Release { get; set; }
        public decimal Price { get; set; }
    }
}
