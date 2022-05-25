using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;
using QuestRoom.Interfaces.Services;
using QuestRoom.Interfaces.UnitOfWork;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.QuestSession.Request;
using QuestRoom.ViewModel.QuestSession.Responce;

namespace QuestRoom.BusinessLogic
{
    public class QuestSessionService : IQuestSessionService
    {
        private IUnitOfWork _unitOfWork;
        private IQuestSessionRepository repository;
        private IQuestRepository questRepository;
        private IClientRepository clientRepository;
        private IDiscountRepository discountRepository;

        public QuestSessionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            repository = _unitOfWork.QuestSessionRepository;
            questRepository = _unitOfWork.QuestRepository;
            clientRepository = _unitOfWork.ClientRepository;
            discountRepository = _unitOfWork.DiscountRepository;
        }

        public async Task<int> Create(CreateQuestSessionViewModel viewModel)
        {
            await Validation(viewModel);

            var questSession = new QuestSession();
            Map(questSession, viewModel);

            await repository.InsertAsync(questSession);
            await _unitOfWork.SaveAsync();

            return questSession.Id;
        }

        private void Map(QuestSession questSession, BaseQuestSessionViewModel viewModel)
        {
            questSession.StartedAt = viewModel.StartedAt;
            questSession.ClientId = viewModel.ClientId;
            questSession.QuestId = viewModel.QuestId;
            questSession.DiscountId = viewModel.DiscountId;
        }

        public async Task Delete(int id)
        {
            await repository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<UpdateQuestSessionViewModel> Get(int id)
        {
            var questSession = await repository.GetByIdAsync(id);
            if (questSession is null)
            {
                throw new ServiceValidationException($"No questSession with id: '{id}'");
            }

            return new UpdateQuestSessionViewModel()
            {
                Id = questSession.Id,
                StartedAt = questSession.StartedAt,
                QuestId = questSession.QuestId,
                ClientId = questSession.ClientId,
                DiscountId = questSession.DiscountId,
            };
        }

        public async Task<ApiResultViewModel<GetQuestSessionViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting)
        {
            return await repository.GetApiResponce(item => new GetQuestSessionViewModel()
            {
                Id = item.Id,
                StartedAt = item.StartedAt,
                ClientEmail = item.Client.Email,
                ClientId = item.ClientId,
                ClientName = item.Client.Name,
                QuestId = item.QuestId,
                QuestName = item.Quest.Name,
                CreatedAt = item.CreatedAt
            }, pageIndex, pageSize, sorting, filters);
        }

        public async Task Update(UpdateQuestSessionViewModel viewModel)
        {
            var questSession = await repository.GetByIdAsync(viewModel.Id);
            if (questSession is null)
            {
                throw new ServiceValidationException($"No questSession with id: '{viewModel.Id}'");
            }

            await Validation(viewModel);

            Map(questSession, viewModel);

            await _unitOfWork.SaveAsync();
        }

        private async Task Validation(BaseQuestSessionViewModel viewModel)
        {
            await ClientValidation(viewModel);
            await QuestValidation(viewModel);
            await TimeValidation(viewModel);
            await DiscountValidation(viewModel);
        }

        private async Task DiscountValidation(BaseQuestSessionViewModel viewModel)
        {
            if (viewModel.DiscountId.HasValue)
            {
                var discount = await discountRepository.GetByIdAsync(viewModel.DiscountId.Value);

                if (discount is null)
                {
                    throw new ServiceValidationException($"No Discount with id: '{viewModel.DiscountId}'");
                }
            }
        }

        private async Task ClientValidation(BaseQuestSessionViewModel viewModel)
        {
            var client = await clientRepository.GetByIdAsync(viewModel.ClientId);

            if (client is null)
            {
                throw new ServiceValidationException($"No Client with id: '{viewModel.ClientId}'");
            }
        }

        private async Task QuestValidation(BaseQuestSessionViewModel viewModel)
        {
            var quest = await questRepository.GetByIdAsync(viewModel.QuestId);

            if (quest is null)
            {
                throw new ServiceValidationException($"No Personal with id: '{viewModel.QuestId}'");
            }
        }

        private async Task TimeValidation(BaseQuestSessionViewModel viewModel)
        {
            var quest = await questRepository.GetByIdAsync(viewModel.QuestId);
            var sessions = await repository.GetByTime(viewModel.StartedAt, quest.Duration);

            if(sessions.Any())
            {
                var questSession = sessions.FirstOrDefault(session => session.QuestId == quest.Id);

                if(questSession != null)
                {
                    throw new ServiceValidationException($"Quest session already reserved sessionId: '{questSession.Id}'");
                }
            }
        }
    }
}