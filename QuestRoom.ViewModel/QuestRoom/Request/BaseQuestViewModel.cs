﻿using QuestRoom.ViewModel.QuestRoom.Request.Items;
using System.ComponentModel.DataAnnotations;

namespace QuestRoom.ViewModel.QuestRoom.Request
{
    public class BaseQuestViewModel
    {
        [Range(0, int.MaxValue)]
        public int MaxPlayerCount { get; set; }

        [Range(0, int.MaxValue)]
        public int MinPlayerCount { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; } = default!;

        [Required]
        [MaxLength(300)]
        public string Description { get; set; } = default!;

        /// <summary>
        /// Event Duration in minutes
        /// </summary>
        [MaxLength(360)]
        public int Duration { get; set; }

        [Range(0, 120)]
        public int? AgeRestriction { get; set; }

        public decimal Price { get; set; }

        public virtual List<QuestTypeItem> Types { get; set; } = new List<QuestTypeItem>();
    }
}