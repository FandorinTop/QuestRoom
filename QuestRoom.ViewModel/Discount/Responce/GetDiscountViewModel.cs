using QuestRoom.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.ViewModel.Discount.Responce
{
    public class GetDiscountViewModel : GetBaseEntityViewModel
    {
        public string Name { get; set; }

        public double Reduction { get; set; }
    }
}
