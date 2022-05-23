using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.ViewModel.Discount.Request
{
    public class BaseDiscountViewModel
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        /// <summary>
        /// % of Discount Range from 0-1
        /// </summary>
        [Range(0d, 1d)]
        public double Reduction { get; set; }
    }
}
