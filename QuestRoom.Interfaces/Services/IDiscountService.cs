using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.Discount.Request;
using QuestRoom.ViewModel.Discount.Responce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.Interfaces.Services
{
    public interface IDiscountService
    {
        public Task<int> Create(CreateDiscountViewModel viewModel);

        public Task Update(UpdateDiscountViewModel viewModel);

        public Task<GetDiscountViewModel> Get(int id);

        public Task<ApiResultViewModel<GetDiscountViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting);
    }
}
