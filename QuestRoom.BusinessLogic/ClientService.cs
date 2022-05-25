using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;
using QuestRoom.Interfaces.Services;
using QuestRoom.Interfaces.UnitOfWork;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.Client.Request;
using QuestRoom.ViewModel.Client.Responce;

namespace QuestRoom.BusinessLogic
{
    public class ClientService : IClientService
    {
        private IUnitOfWork _unitOfWork;
        private IClientRepository repository;

        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            repository = _unitOfWork.ClientRepository;
        }

        public async Task<int> Create(CreateClientViewModel viewModel)
        {
            var client = new Client();
            Map(client, viewModel);

            await repository.InsertAsync(client);
            await _unitOfWork.SaveAsync();

            return client.Id;
        }

        public async Task<UpdateClientViewModel> Get(int id)
        {
            var Client = await repository.GetByIdAsync(id);

            if (Client is null)
            {
                throw new ServiceValidationException($"No Client with id: '{id}'");
            }

            return Extract(Client);
        }

        public async Task Update(UpdateClientViewModel viewModel)
        {
            var client = await repository.GetByIdAsync(viewModel.Id);

            if (client is null)
            {
                throw new ServiceValidationException($"No Client with id: '{viewModel.Id}'");
            }

            Map(client, viewModel);

            repository.Update(client);
            await _unitOfWork.SaveAsync();

        }

        public async Task<ApiResultViewModel<GetClientViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting)
        {
            return await repository.GetApiResponce(item => new GetClientViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Email = item.Email,
                PhoneNumbe = item.PhoneNumbe,
                CreatedAt = item.CreatedAt
            }, pageIndex, pageSize, sorting, filters);
        }

        private void Map(Client client, BaseClientViewModel viewModel)
        {
            client.Name = viewModel.Name;
            client.Email = viewModel.Email;
            client.PhoneNumbe = viewModel.PhoneNumbe;
        }

        private UpdateClientViewModel Extract(Client client) => new UpdateClientViewModel()
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            PhoneNumbe = client.PhoneNumbe,
        };

        public async Task Delete(int id)
        {
            await repository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}