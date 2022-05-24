using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.Type.Request;
using QuestRoom.ViewModel.Type.Responce;

namespace QuestRoom.Interfaces.Services
{
    public interface IQuestTypeNameService
    {
        public Task<int> Create(CreateQuestTypeNameViewModel viewModel);

        public Task Update(UpdateQuestTypeNameViewModel viewModel);

        public Task<UpdateQuestTypeNameViewModel> Get(int id);

        public Task Delete(int id);

        public Task<ApiResultViewModel<GetQuestTypeNameViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting);
    }
}
