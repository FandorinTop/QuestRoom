using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.Quest.Request;
using QuestRoom.ViewModel.Quest.Responce;

namespace QuestRoom.Interfaces.Services
{
    public interface IQuestService
    {
        public Task<int> Create(CreateQuestViewModel viewModel);

        public Task Update(UpdateQuestViewModel viewModel);

        public Task<GetQuestViewModel> Get(int id);

        public Task<ApiResultViewModel<GetQuestViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting);
    }
}
