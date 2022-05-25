using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;
using QuestRoom.Interfaces.Services;
using QuestRoom.Interfaces.UnitOfWork;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.Type.Request;
using QuestRoom.ViewModel.Type.Responce;

namespace QuestRoom.BusinessLogic
{
    public class QuestTypeNameService : IQuestTypeNameService
    {
        private IUnitOfWork _unitOfWork;
        private IQuestTypeNameRepository repository;

        public QuestTypeNameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            repository = _unitOfWork.QuestTypeNameRepository;
        }

        public async Task<int> Create(CreateQuestTypeNameViewModel viewModel)
        {
            var questTypeName = await repository.FindByName(viewModel.Name);

            if (questTypeName is not null)
            {
                throw new ServiceValidationException($"Db already has QuestTypeName with name: {viewModel.Name}, QuestTypeNameId: '{questTypeName.Id}'");
            }

            questTypeName = new QuestTypeName();
            Map(questTypeName, viewModel);

            await repository.InsertAsync(questTypeName);
            await _unitOfWork.SaveAsync();

            return questTypeName.Id;
        }

        public async Task<UpdateQuestTypeNameViewModel> Get(int id)
        {
            var questTypeName = await repository.GetByIdAsync(id);

            if (questTypeName is null)
            {
                throw new ServiceValidationException($"No discount with id: '{id}'");
            }

            return Extract(questTypeName);
        }

        public async Task<ApiResultViewModel<GetQuestTypeNameViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting)
        {
            return await repository.GetApiResponce(item => new GetQuestTypeNameViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                CreatedAt = item.CreatedAt
            }, pageIndex, pageSize, sorting, filters);
        }

        public async Task Update(UpdateQuestTypeNameViewModel viewModel)
        {
            var questTypeName = await repository.FindByName(viewModel.Name);


            if (questTypeName?.Id != viewModel.Id && questTypeName != null)
            {
                throw new ServiceValidationException($"Db already has questTypeName with name: {viewModel.Name}, questTypeNameId: '{questTypeName.Id}'");
            }

            questTypeName = await repository.GetByIdAsync(viewModel.Id);

            if (questTypeName is null)
            {
                throw new ServiceValidationException($"No questTypeName with id: '{viewModel.Id}'");
            }

            Map(questTypeName, viewModel);

            repository.Update(questTypeName);
            await _unitOfWork.SaveAsync();
        }

        private void Map(QuestTypeName discount, BaseQuestTypeNameViewModel viewModel)
        {
            discount.Name = viewModel.Name;
        }

        private UpdateQuestTypeNameViewModel Extract(QuestTypeName discount) => new UpdateQuestTypeNameViewModel()
        {
            Id = discount.Id,
            Name = discount.Name,
        };

        public async Task Delete(int id)
        {
            await repository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}