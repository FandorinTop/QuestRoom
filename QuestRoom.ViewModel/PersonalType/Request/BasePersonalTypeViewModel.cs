using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.ViewModel.PersonalType.Request
{
    public class BasePersonalTypeViewModel
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; } = default!;
    }
}
