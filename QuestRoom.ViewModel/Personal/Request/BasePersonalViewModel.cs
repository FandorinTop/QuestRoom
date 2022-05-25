
using QuestRoom.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.ViewModel.Personal.Request
{
    public class BasePersonalViewModel
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; } = default!;

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        [Required]
        public int? PersonalTypeId { get; set; } = default!;

        [Required]
        [EmailAddress]
        [MaxLength(64)]
        public string Email { get; set; } = default!;

        [Required]
        [Phone]
        [MaxLength(64)]
        public string PhoneNumber { get; set; } = default!;
    }
}
