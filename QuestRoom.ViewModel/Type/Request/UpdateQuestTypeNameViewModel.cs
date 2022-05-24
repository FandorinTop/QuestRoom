using System.ComponentModel.DataAnnotations;

namespace QuestRoom.ViewModel.Type.Request
{
    public class UpdateQuestTypeNameViewModel : BaseQuestTypeNameViewModel
    {
        [Required]
        public int? Id { get; set; } = default!;
    }
}
