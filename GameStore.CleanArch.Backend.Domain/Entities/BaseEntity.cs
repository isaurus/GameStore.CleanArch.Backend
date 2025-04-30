namespace GameStore.CleanArch.Backend.Domain.Entities
{
    public class BaseEntity
    {
        public int Id{ get; set; }
        public bool IsEnabled { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedTimeUtc { get; set; }
    }
}
