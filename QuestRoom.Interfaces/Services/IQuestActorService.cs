using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.QuestActor.Request;
using QuestRoom.ViewModel.QuestActor.Responce;

namespace QuestRoom.Interfaces.Services
{
    public interface IQuestActorService
    {
        public Task<int> Create(CreateQuestActorViewModel viewModel);

        public Task Update(UpdateQuestActorViewModel viewModel);

        public Task<GetQuestActorViewModel> Get(int id);

        public Task<ApiResultViewModel<GetQuestActorViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting);
    }
}
