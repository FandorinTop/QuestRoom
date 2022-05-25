using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;
using QuestRoom.Interfaces.Services;
using QuestRoom.Interfaces.UnitOfWork;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.Discount.Request;
using QuestRoom.ViewModel.Discount.Responce;

namespace QuestRoom.BusinessLogic
{

    public class DiscountService : IDiscountService
    {
        private IUnitOfWork _unitOfWork;
        private IDiscountRepository repository;

        public DiscountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            repository = _unitOfWork.DiscountRepository;
        }

        public async Task<int> Create(CreateDiscountViewModel viewModel)
        {
            var discount = await repository.FindByName(viewModel.Name);

            if (discount is not null)
            {
                throw new ServiceValidationException($"Db already has discount with name: {viewModel.Name}, discountId: '{discount.Id}'");
            }

            discount = new Discount();
            Map(discount, viewModel);

            await repository.InsertAsync(discount);
            await _unitOfWork.SaveAsync();

            return discount.Id;
        }

        public async Task<UpdateDiscountViewModel> Get(int id)
        {
            var discount = await repository.GetByIdAsync(id);

            if (discount is null)
            {
                throw new ServiceValidationException($"No discount with id: '{id}'");
            }

            return Extract(discount);
        }

        public async Task Update(UpdateDiscountViewModel viewModel)
        {
            var discount = await repository.FindByName(viewModel.Name);

            if (discount?.Id != viewModel.Id && discount != null)
            {
                throw new ServiceValidationException($"Db already has discount with name: {viewModel.Name}, discountId: '{discount.Id}'");
            }

            discount = await repository.GetByIdAsync(viewModel.Id);

            if (discount is null)
            {
                throw new ServiceValidationException($"No discount with id: '{viewModel.Id}'");
            }

            Map(discount, viewModel);

            repository.Update(discount);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ApiResultViewModel<GetDiscountViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting)
        {
            return await repository.GetApiResponce(item => new GetDiscountViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Reduction = item.Reduction,
                CreatedAt = item.CreatedAt
            }, pageIndex,  pageSize, sorting, filters);
        }

        private void Map(Discount discount, BaseDiscountViewModel viewModel)
        {
            discount.Reduction = viewModel.Reduction;
            discount.Name = viewModel.Name;
        }

        private UpdateDiscountViewModel Extract(Discount discount) => new UpdateDiscountViewModel()
        {
            Id = discount.Id,
            Reduction = discount.Reduction,
            Name = discount.Name,
        };

        public async Task Delete(int id)
        {
            await repository.DeleteAsync(id);
        }
    }
}