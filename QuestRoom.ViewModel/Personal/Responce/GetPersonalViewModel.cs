using QuestRoom.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.ViewModel.Personal.Responce
{
    public class GetPersonalViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public int? PersonalTypeId { get; set; } = default!;

        public string PersonalTypeName { get; set; }

        public string Email { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public DateTime CreatedAt { get; set; }
    }
}
