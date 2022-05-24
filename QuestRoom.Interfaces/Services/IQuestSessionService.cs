using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.QuestSession.Request;
using QuestRoom.ViewModel.QuestSession.Responce;

namespace QuestRoom.Interfaces.Services
{
    public interface IQuestSessionService
    {
        public Task<int> Create(CreateQuestSessionViewModel viewModel);

        public Task Update(UpdateQuestSessionViewModel viewModel);

        public Task<GetQuestSessionViewModel> Get(int id);

        public Task<ApiResultViewModel<GetQuestSessionViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting);
    }
}
