using System.ComponentModel.DataAnnotations;

namespace QuestRoom.DomainModel
{
    public class PersonalType : BaseEntity
    {
        private string name;

        [Required]
        [MaxLength(64)]
        public string NormalizedName { get; private set; }

        [Required]
        [MaxLength(64)]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                    NormalizedName = name.ToUpperInvariant();
                }
            }
        }
    }
}