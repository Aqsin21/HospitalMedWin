namespace Hospital.DAL.DataContext.Entities
{
    public class Room : BaseEntity
    {
        public required int RoomNumber { get; set; }
        public required string Type { get; set; } 
        public bool IsAvailable { get; set; }
        public  string? ImagePath { get; set; }
    }
}
