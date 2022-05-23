using System.ComponentModel.DataAnnotations;

namespace QuestRoom.ViewModel.QuestRoom.Request
{
    public class UpdateQuestViewModel : BaseQuestViewModel
    {
        [Required]
        public int? Id { get; set; } = default!;
    }
}
