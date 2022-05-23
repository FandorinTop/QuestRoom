using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.ViewModel.QuestType.Request
{
    public class BaseQuestTypeViewModel
    {
        [Required]
        public int? QuestType { get; set; }

        [Required]
        public int? QuestRoom { get; set; }
    }
}
