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
        }

        public async Task<int> Create(CreateQuestViewModel viewModel)
        {
            var quest = new Quest();
            Map(quest, viewModel);
            await repository.InsertAsync(quest);
            await _unitOfWork.SaveAsync();

            return quest.Id;
        }

        public async Task<GetQuestViewModel> Get(int id)
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
                Price = item.Price
            }, pageIndex, pageSize, sorting, filters);
        }

        private void Map(Quest Quest, BaseQuestViewModel viewModel)
        {
            Quest.Name = viewModel.Name;
            Quest.AgeRestriction = viewModel.AgeRestriction;
            Quest.Description = viewModel.Description;
            Quest.Duration = viewModel.Duration;
            Quest.MaxPlayerCount = viewModel.MaxPlayerCount;
            Quest.MinPlayerCount = viewModel.MinPlayerCount;
            Quest.Price = viewModel.Price;
        }

        private GetQuestViewModel Extract(Quest Quest) => new GetQuestViewModel()
        {
            Id = Quest.Id,
            Name = Quest.Name,
            CreatedAt = Quest.CreatedAt,
            AgeRestriction = Quest.AgeRestriction,
            Description = Quest.Description,
            Duration = Quest.Duration,
            MaxPlayerCount = Quest.MaxPlayerCount,
            MinPlayerCount = Quest.MinPlayerCount,
            Price = Quest.Price
        };
    }
}