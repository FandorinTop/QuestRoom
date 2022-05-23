using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestRoom.DomainModel
{
    public class Quest : BaseEntity
    {
        [Range(0, int.MaxValue)]
        public int MaxPlayerCount { get; set; }

        [Range(0, int.MaxValue)]
        public int MinPlayerCount { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        /// <summary>
        /// Event Duration in minutes
        /// </summary>
        [MaxLength(360)]
        public int Duration { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// Available only for client above this value
        /// </summary>
        [Range(0, 120)]
        public int? AgeRestriction { get; set; }

        public virtual List<QuestType> Types { get; set; } = new List<QuestType>();
    }
}