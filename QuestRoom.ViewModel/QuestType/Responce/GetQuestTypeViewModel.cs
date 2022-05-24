using QuestRoom.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.ViewModel.QuestType.Responce
{
    public class GetQuestTypeViewModel : GetBaseEntityViewModel
    {
        public int? QuestTypeId { get; set; }

        public int? QuestRoomId { get; set; }
    }
}
