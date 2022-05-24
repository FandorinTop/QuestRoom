using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.QuestActorSet.Request;
using QuestRoom.ViewModel.QuestActorSet.Responce;

namespace QuestRoom.Interfaces.Services
{
    public interface IQuestActorSetService
    {
        public Task<int> Create(CreateQuestActorSetViewModel viewModel);

        public Task Update(UpdateQuestActorSetViewModel viewModel);

        public Task<GetQuestActorSetViewModel> Get(int id);

        public Task<ApiResultViewModel<GetQuestActorSetViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting);
    }
}
