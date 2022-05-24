using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.ViewModel.Common
{
    public class FilterRequest
    {
        /// <summary>
        /// Filter Column name (or null if none set)
        /// </summary>
        public string FilterColumn { get; set; }

        /// <summary>
        /// Filter Query string 
        /// (to be used within the given FilterColumn)
        /// </summary>
        public string FilterQuery { get; set; }

        public bool IsPartFilter { get; set; } = true;
    }
}
