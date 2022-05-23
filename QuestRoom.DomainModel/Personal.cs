using QuestRoom.Common;
using System.ComponentModel.DataAnnotations;

namespace QuestRoom.DomainModel
{
    public class Personal : BaseEntity
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public int PersonalTypeId { get; set; }

        public virtual PersonalType PersonalType { get; set; } = default!;
    }
}