using QuestRoom.ViewModel.Discount.Request;
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

        public Task Update(CreateDiscountViewModel viewModel);

        //public Task<GetDiscountViewModel> Get(CreateDiscountViewModel viewModel);

        //public Task<ApiResult<GetDiscountViewModel>> GetAll(CreateDiscountViewModel viewModel);
    }
}
