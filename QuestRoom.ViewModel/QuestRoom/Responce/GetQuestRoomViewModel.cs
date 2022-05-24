using QuestRoom.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.ViewModel.Quest.Responce
{
    public class GetQuestViewModel : GetBaseEntityViewModel
    {
        public int MaxPlayerCount { get; set; }

        public int MinPlayerCount { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Event Duration in minutes
        /// </summary>
        public int Duration { get; set; }

        public decimal Price { get; set; }

        /// <summary>
        /// Available only for client above this value
        /// </summary>
        public int? AgeRestriction { get; set; }
    }
}
