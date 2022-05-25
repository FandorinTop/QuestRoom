using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;
using QuestRoom.Interfaces.Services;
using QuestRoom.Interfaces.UnitOfWork;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.Quest.Request;
using QuestRoom.ViewModel.Quest.Responce;

namespace QuestRoom.BusinessLogic
{
    public class QuestService : IQuestService
    {
        private IUnitOfWork _unitOfWork;
        private IQuestRepository repository;
        private IQuestTypeNameRepository typeRepository;

        public QuestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            repository = _unitOfWork.QuestRepository;
            typeRepository = _unitOfWork.QuestTypeNameRepository;
        }

        public async Task<int> Create(CreateQuestViewModel viewModel)
        {
            var quest = new Quest();

            await Validate(viewModel);

            Map(quest, viewModel);
            await repository.InsertAsync(quest);
            await _unitOfWork.SaveAsync();

            return quest.Id;
        }

        public async Task<UpdateQuestViewModel> Get(int id)
        {
            var Quest = await repository.GetByIdAsync(id);

            if (Quest is null)
            {
                throw new ServiceValidationException($"No Quest with id: '{id}'");
            }

            return Extract(Quest);
        }

        public async Task Update(UpdateQuestViewModel viewModel)
        {
            var quest = await repository.GetByIdAsync(viewModel.Id);

            if (quest is null)
            {
                throw new ServiceValidationException($"No Quest with id: '{viewModel.Id}'");
            }

            await Validate(viewModel);

            Map(quest, viewModel);
            repository.Update(quest);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ApiResultViewModel<GetQuestViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting)
        {
            return await repository.GetApiResponce(item => new GetQuestViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                CreatedAt = item.CreatedAt,
                AgeRestriction = item.AgeRestriction,
                Description = item.Description,
                Duration = item.Duration,
                MaxPlayerCount = item.MaxPlayerCount,
                MinPlayerCount = item.MinPlayerCount,
                Price = item.Price,
                Type = item.QuestTypeName.Name
            }, pageIndex, pageSize, sorting, filters);
        }

        private void Map(Quest quest, BaseQuestViewModel viewModel)
        {
            quest.Name = viewModel.Name;
            quest.AgeRestriction = viewModel.AgeRestriction;
            quest.Description = viewModel.Description;
            quest.Duration = viewModel.Duration;
            quest.MaxPlayerCount = viewModel.MaxPlayerCount;
            quest.MinPlayerCount = viewModel.MinPlayerCount;
            quest.Price = viewModel.Price;
            quest.QuestTypeNameId = viewModel.QuestTypeId.Value;
        }

        private UpdateQuestViewModel Extract(Quest quest) => new UpdateQuestViewModel()
        {
            Id = quest.Id,
            Name = quest.Name,
            AgeRestriction = quest.AgeRestriction,
            Description = quest.Description,
            Duration = quest.Duration,
            MaxPlayerCount = quest.MaxPlayerCount,
            MinPlayerCount = quest.MinPlayerCount,
            QuestTypeId = quest.QuestTypeNameId,
            Price = quest.Price
        };

        public async Task Delete(int id)
        {
            await repository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task Validate(BaseQuestViewModel viewModel)
        {
            var questType = await typeRepository.GetByIdAsync(viewModel.QuestTypeId.Value);

            if(questType is null)
            {
                throw new ServiceValidationException($"No QuestType with id: '{viewModel.QuestTypeId}'");
            }
        }
    }
}