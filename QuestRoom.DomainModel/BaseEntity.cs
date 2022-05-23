using System.ComponentModel.DataAnnotations;

namespace QuestRoom.DomainModel
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? DeltedAt { get; set; }
    }
}