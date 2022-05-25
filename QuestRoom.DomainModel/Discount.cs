using System.ComponentModel.DataAnnotations;

namespace QuestRoom.DomainModel
{
    public class Discount : BaseEntity
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

        /// <summary>
        /// % of Discount Range from 0-1
        /// </summary>
        [Range(0d, 1d)]
        public double Reduction { get; set; }

        public virtual List<QuestSession> QuestSessions { get; set; } = new List<QuestSession>();
    }
}