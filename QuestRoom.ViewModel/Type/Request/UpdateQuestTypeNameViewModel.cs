using System.ComponentModel.DataAnnotations;

namespace QuestRoom.ViewModel.Type.Request
{
    public class UpdateQuestTypeNameViewModel : BaseQuestTypeNameViewModel
    {
        public int Id { get; set; } = default!;
    }
}
