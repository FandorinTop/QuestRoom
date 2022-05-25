using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.ViewModel.QuestSession.Request
{
    public class BaseQuestSessionViewModel
    {
        public DateTime StartedAt { get; set; }

        [Required]
        public int? ClientId { get; set; }

        [Required]
        public int? QuestId { get; set; }

        public int? DiscountId { get; set; }
    }
}
