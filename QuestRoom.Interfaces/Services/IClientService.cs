using QuestRoom.ViewModel.Client.Request;
using QuestRoom.ViewModel.Client.Responce;
using QuestRoom.ViewModel.Common;

namespace QuestRoom.Interfaces.Services
{
    public interface IClientService
    {
        public Task<int> Create(CreateClientViewModel viewModel);

        public Task Update(UpdateClientViewModel viewModel);

        public Task<UpdateClientViewModel> Get(int id);

        public Task Delete(int id);

        public Task<ApiResultViewModel<GetClientViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting);
    }
}
