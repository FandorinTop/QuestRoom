using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;
using QuestRoom.Interfaces.Services;
using QuestRoom.Interfaces.UnitOfWork;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.Personal.Request;
using QuestRoom.ViewModel.Personal.Responce;

namespace QuestRoom.BusinessLogic
{
    public class PersonalService : IPersonalService
    {
        private IUnitOfWork _unitOfWork;
        private IPersonalRepository repository;
        private IPersonalTypeRepository typeRepository;

        public PersonalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            repository = _unitOfWork.PersonalRepository;
        }

        public async Task<int> Create(CreatePersonalViewModel viewModel)
        {
            var type = await typeRepository.GetByIdAsync(viewModel.PersonalTypeId);

            if (type is null)
            {
                throw new ServiceValidationException($"No PersonalType with id:'{viewModel.PersonalTypeId}'");
            }

            var personal = new Personal();
            Map(personal, viewModel);

            await repository.InsertAsync(personal);
            await _unitOfWork.SaveAsync();

            return personal.Id;
        }

        public async Task<GetPersonalViewModel> Get(int id)
        {
            var Personal = await repository.GetByIdAsync(id);

            if (Personal is null)
            {
                throw new ServiceValidationException($"No Personal with id: '{id}'");
            }

            return Extract(Personal);
        }

        public async Task Update(UpdatePersonalViewModel viewModel)
        {
            var personal = await repository.GetByIdAsync(viewModel.Id);

            if (personal is null)
            {
                throw new ServiceValidationException($"No Personal with id: '{viewModel.Id}'");
            }

            var type = await typeRepository.GetByIdAsync(viewModel.PersonalTypeId);

            if (type is null)
            {
                throw new ServiceValidationException($"No PersonalType with id: '{viewModel.PersonalTypeId}'");
            }

            Map(personal, viewModel);

            repository.Update(personal);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ApiResultViewModel<GetPersonalViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting)
        {
            return await repository.GetApiResponce(item => new GetPersonalViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                CreatedAt = item.CreatedAt
            }, pageIndex, pageSize, sorting, filters);
        }

        private void Map(Personal Personal, BasePersonalViewModel viewModel)
        {
            Personal.Name = viewModel.Name;
            Personal.PersonalTypeId = viewModel.PersonalTypeId;
            Personal.Email = viewModel.Email;
            Personal.Gender = viewModel.Gender;
            Personal.PhoneNumber = viewModel.PhoneNumber;
            Personal.BirthDate = viewModel.BirthDate;
        }

        private GetPersonalViewModel Extract(Personal personal) => new GetPersonalViewModel()
        {
            Id = personal.Id,
            Name = personal.Name,
            CreatedAt = personal.CreatedAt,
            BirthDate = personal.BirthDate,
            Email = personal.Email,
            Gender = personal.Gender,
            PersonalTypeId = personal.PersonalTypeId,
            PersonalTypeName = personal.PersonalType.Name,
            PhoneNumber = personal.PhoneNumber
        };
    }
}