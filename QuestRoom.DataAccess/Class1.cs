namespace QuestRoom.DataAccess
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? DeltedAt { get; set; }
    }
}