using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.Personal.Request;
using QuestRoom.ViewModel.Personal.Responce;
using QuestRoom.ViewModel.Quest.Request;
using QuestRoom.ViewModel.Quest.Responce;

namespace QuestRoom.Interfaces.Services
{
    public interface IPersonalService
    {
        public Task<int> Create(CreatePersonalViewModel viewModel);

        public Task Update(UpdatePersonalViewModel viewModel);

        public Task<UpdatePersonalViewModel> Get(int id);

        public Task Delete(int id);

        public Task<ApiResultViewModel<GetPersonalViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting);
    }
}
