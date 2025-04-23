namespace GameStore.CleanArch.Backend.Domain.Entities
{
    public class Game : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly Release { get; set; }
        public decimal Price { get; set; }
    }
}
