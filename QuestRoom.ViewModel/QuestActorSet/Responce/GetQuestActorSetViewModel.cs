using QuestRoom.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.ViewModel.QuestActorSet.Responce
{
    internal class GetQuestActorSetViewModel : GetBaseEntityViewModel
    {
        public int QuestId { get; set; }
    }
}
