using System.ComponentModel.DataAnnotations;

namespace QuestRoom.DomainModel
{
    public class Client : BaseEntity
    {
        [MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(128)]
        [Phone]
        public string Email { get; set; }

        [MaxLength(128)]
        [Phone]
        public string PhoneNumbe { get; set; }
    }
}