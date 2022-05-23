using System.ComponentModel.DataAnnotations;

namespace QuestRoom.DomainModel
{
    public class Type : BaseEntity
    {
        private string name;

        [Required]
        [MaxLength(64)]
        public string NormalizedName { get; private set; }

        [Required]
        [MaxLength(64)]
        public string Name { 
            get
            {
                return name;
            }
            set
            {
                if (!string.IsNullOrEmpty(name))
                {
                    name = value;
                    NormalizedName = name.ToUpperInvariant();
                }
            }
        }

        public virtual List<QuestType> Quests { get; set; } = new List<QuestType>();
    }
}