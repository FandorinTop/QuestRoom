using QuestRoom.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.ViewModel.QuestSession.Responce
{
    public class GetQuestSessionViewModel : GetBaseEntityViewModel
    {
        public DateTime StartedAt { get; set; }

        [Required]
        public int? ClientId { get; set; }

        public string ClientName { get; set; }

        public string ClientEmail { get; set; }

        [Required]
        public int? QuestId { get; set; }

        public string QuestName { get; set; }
    }
}
