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

        public int ParticipantCount { get; set; }

        [Required]
        public int? ClientId { get; set; }

        [Required]
        public int? QuestActorSetId { get; set; }
    }
}
