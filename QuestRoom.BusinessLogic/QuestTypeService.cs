using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;
using QuestRoom.Interfaces.Services;
using QuestRoom.Interfaces.UnitOfWork;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.QuestType.Request;
using QuestRoom.ViewModel.QuestType.Responce;

namespace QuestRoom.BusinessLogic
{
    public class QuestTypeService : IQuestTypeService
    {
        private IUnitOfWork _unitOfWork;
        private IQuestTypeRepository repository;

        public QuestTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            repository = _unitOfWork.QuestTypeRepository;
        }

        public async Task<int> Create(CreateQuestTypeViewModel viewModel)
        {
            var QuestTypeId = await repository.CreateSingle(viewModel.QuestRoomId, viewModel.QuestTypeId);
            await _unitOfWork.SaveAsync();

            return QuestTypeId;
        }

        public async Task<UpdateQuestTypeViewModel> Get(int id)
        {
            var QuestType = await repository.GetByIdAsync(id);

            if (QuestType is null)
            {
                throw new ServiceValidationException($"No QuestType with id: '{id}'");
            }

            return Extract(QuestType);
        }

        public async Task Update(UpdateQuestTypeViewModel viewModel)
        {
            var QuestTypeId = await repository.CreateSingle(viewModel.QuestRoomId, viewModel.QuestTypeId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ApiResultViewModel<GetQuestTypeViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting)
        {
            return await repository.GetApiResponce(item => new GetQuestTypeViewModel()
            {
                Id = item.Id,
                QuestRoomId = item.QuestRoomId,
                QuestTypeId = item.TypeId,
                CreatedAt = item.CreatedAt
            }, pageIndex, pageSize, sorting, filters);
        }

        private UpdateQuestTypeViewModel Extract(QuestType item) => new UpdateQuestTypeViewModel()
        {
            Id = item.Id,
            QuestRoomId = item.QuestRoomId,
            QuestTypeId = item.TypeId,
        };

        public async Task Delete(int id)
        {
            await repository.DeleteAsync(id);
        }
    }
}