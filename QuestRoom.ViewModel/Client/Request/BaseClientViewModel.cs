using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.ViewModel.Client.Request
{
    public class BaseClientViewModel
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(128)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(128)]
        [Phone]
        public string PhoneNumbe { get; set; }
    }
}
