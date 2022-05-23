using System.ComponentModel.DataAnnotations;

namespace QuestRoom.ViewModel.Type.Request
{
    public class UpdateTypeViewModel : BaseTypeViewModel
    {
        [Required]
        public int? Id { get; set; } = default!;
    }
}
