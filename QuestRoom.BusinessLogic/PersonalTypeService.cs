using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;
using QuestRoom.Interfaces.Services;
using QuestRoom.Interfaces.UnitOfWork;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.PersonalType.Request;
using QuestRoom.ViewModel.PersonalType.Responce;

namespace QuestRoom.BusinessLogic
{
    public class PersonalTypeService : IPersonalTypeService
    {
        private IUnitOfWork _unitOfWork;
        private IPersonalTypeRepository repository;

        public PersonalTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            repository = _unitOfWork.PersonalTypeRepository;
        }

        public async Task<int> Create(CreatePersonalTypeViewModel viewModel)
        {
            var personalType = await repository.FindByName(viewModel.Name);

            if (personalType is not null)
            {
                throw new ServiceValidationException($"Db already has PersonalType with name: {viewModel.Name}, PersonalTypeId: '{personalType.Id}'");
            }

            personalType = new PersonalType();
            Map(personalType, viewModel);

            await repository.InsertAsync(personalType);
            await _unitOfWork.SaveAsync();

            return personalType.Id;
        }

        public async Task<UpdatePersonalTypeViewModel> Get(int id)
        {
            var PersonalType = await repository.GetByIdAsync(id);

            if (PersonalType is null)
            {
                throw new ServiceValidationException($"No PersonalType with id: '{id}'");
            }

            return Extract(PersonalType);
        }

        public async Task Update(UpdatePersonalTypeViewModel viewModel)
        {
            var personalType = await repository.FindByName(viewModel.Name);

            if (personalType?.Id != viewModel.Id && personalType != null)
            {
                throw new ServiceValidationException($"Db already has PersonalType with name: {viewModel.Name}, PersonalTypeId: '{personalType.Id}'");
            }

            personalType = await repository.GetByIdAsync(viewModel.Id);

            if (personalType is null)
            {
                throw new ServiceValidationException($"No PersonalType with id: '{viewModel.Id}'");
            }

            Map(personalType, viewModel);

            repository.Update(personalType);
            await _unitOfWork.SaveAsync();

        }

        public async Task<ApiResultViewModel<GetPersonalTypeViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting)
        {
            return await repository.GetApiResponce(item => new GetPersonalTypeViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                CreatedAt = item.CreatedAt
            }, pageIndex, pageSize, sorting, filters);
        }

        private void Map(PersonalType PersonalType, BasePersonalTypeViewModel viewModel)
        {
            PersonalType.Name = viewModel.Name;
        }

        private UpdatePersonalTypeViewModel Extract(PersonalType PersonalType) => new UpdatePersonalTypeViewModel()
        {
            Id = PersonalType.Id,
            Name = PersonalType.Name,
        };

        public async Task Delete(int id)
        {
            await repository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}