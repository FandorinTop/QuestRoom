using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.QuestType.Request;
using QuestRoom.ViewModel.QuestType.Responce;

namespace QuestRoom.Interfaces.Services
{
    public interface IQuestTypeService
    {
        public Task<int> Create(CreateQuestTypeViewModel viewModel);

        public Task Update(UpdateQuestTypeViewModel viewModel);

        public Task<GetQuestTypeViewModel> Get(int id);

        public Task<ApiResultViewModel<GetQuestTypeViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting);
    }
}
