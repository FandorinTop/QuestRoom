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
            typeRepository = unitOfWork.PersonalTypeRepository;
        }

        public async Task<int> Create(CreatePersonalViewModel viewModel)
        {
            var type = await typeRepository.GetByIdAsync(viewModel.PersonalTypeId.Value);

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

        public async Task<UpdatePersonalViewModel> Get(int id)
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

            var type = await typeRepository.GetByIdAsync(viewModel.PersonalTypeId.Value);

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
                BirthDate = item.BirthDate,
                Email = item.Email,
                Gender = item.Gender,
                PersonalTypeId = item.PersonalTypeId,
                PersonalTypeName = item.PersonalType.Name,
                PhoneNumber = item.PhoneNumber,
                CreatedAt = item.CreatedAt
            }, pageIndex, pageSize, sorting, filters);
        }

        private void Map(Personal Personal, BasePersonalViewModel viewModel)
        {
            Personal.Name = viewModel.Name;
            Personal.PersonalTypeId = viewModel.PersonalTypeId.Value;
            Personal.Email = viewModel.Email;
            Personal.Gender = viewModel.Gender;
            Personal.PhoneNumber = viewModel.PhoneNumber;
            Personal.BirthDate = viewModel.BirthDate;
        }

        private UpdatePersonalViewModel Extract(Personal personal) => new UpdatePersonalViewModel()
        {
            Id = personal.Id,
            Name = personal.Name,
            BirthDate = personal.BirthDate,
            Email = personal.Email,
            Gender = personal.Gender,
            PersonalTypeId = personal.PersonalTypeId,
            PhoneNumber = personal.PhoneNumber
        };

        public async Task Delete(int id)
        {
            await repository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}