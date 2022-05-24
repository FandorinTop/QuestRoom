using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.PersonalType.Request;
using QuestRoom.ViewModel.PersonalType.Responce;

namespace QuestRoom.Interfaces.Services
{
    public interface IPersonalTypeService
    {
        public Task<int> Create(CreatePersonalTypeViewModel viewModel);

        public Task Update(UpdatePersonalTypeViewModel viewModel);

        public Task<UpdatePersonalTypeViewModel> Get(int id);

        public Task Delete(int id);

        public Task<ApiResultViewModel<GetPersonalTypeViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting);
    }
}
