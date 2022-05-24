using QuestRoom.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.ViewModel.Client.Responce
{
    public class GetClientViewModel : GetBaseEntityViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumbe { get; set; }
    }
}
