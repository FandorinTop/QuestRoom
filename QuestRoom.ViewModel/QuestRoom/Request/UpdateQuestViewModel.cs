using System.ComponentModel.DataAnnotations;

namespace QuestRoom.ViewModel.Quest.Request
{
    public class UpdateQuestViewModel : BaseQuestViewModel
    {
        [Required]
        public int? Id { get; set; } = default!;
    }
}
