using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;
using QuestRoom.Interfaces.Services;
using QuestRoom.Interfaces.UnitOfWork;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.QuestActor.Request;
using QuestRoom.ViewModel.QuestActor.Responce;

namespace QuestRoom.BusinessLogic
{
    public class QuestActorService : IQuestActorService
    {
        private IUnitOfWork _unitOfWork;
        private IQuestActorRepository repository;

        public QuestActorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            repository = _unitOfWork.QuestActorRepository;
        }

        public async Task<int> Create(CreateQuestActorViewModel viewModel)
        {
            var questActorId = await repository.CreateSingle(viewModel.PersonalId, viewModel.QuestId);
            await _unitOfWork.SaveAsync();

            return questActorId;
        }

        public async Task<UpdateQuestActorViewModel> Get(int id)
        {
            var questActor = await repository.GetByIdAsync(id);

            if (questActor is null)
            {
                throw new ServiceValidationException($"No QuestActor with id: '{id}'");
            }

            return Extract(questActor);
        }

        public async Task Update(UpdateQuestActorViewModel viewModel)
        {
            var questActorId = await repository.CreateSingle(viewModel.PersonalId, viewModel.QuestId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ApiResultViewModel<GetQuestActorViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting)
        {
            return await repository.GetApiResponce(item => new GetQuestActorViewModel()
            {
                Id = item.Id,
                PersonalId = item.PersonalId,
                QuestId = item.QuestId,
                PersonalName = item.Personal.Name,
                CreatedAt = item.CreatedAt
            }, pageIndex, pageSize, sorting, filters);
        }

        private UpdateQuestActorViewModel Extract(QuestActor item) => new UpdateQuestActorViewModel()
        {
            Id = item.Id,
            PersonalId = item.PersonalId,
            QuestId = item.QuestId,
        };

        public async Task Delete(int id)
        {
            await repository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}