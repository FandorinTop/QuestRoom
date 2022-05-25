using QuestRoom.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.ViewModel.QuestActor.Responce
{
    public class GetQuestActorViewModel : GetBaseEntityViewModel
    {
        public int PersonalId { get; set; }

        public string PersonalName { get; set; }

        public int QuestId { get; set; }
    }
}
