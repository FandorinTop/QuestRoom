using Microsoft.AspNetCore.Mvc;
using QuestRoom.Interfaces.Services;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.Discount.Responce;
using System.Linq;

namespace QuestRoom.Web.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        IDiscountService _discountService;

        public DiscountController()
        {
            //_discountService = discountService;
        }

        [HttpPost]
        public async Task<IActionResult> GetApiResponce(GetApiBodyRequest viewModel)
        {
            var data = new List<GetDiscountViewModel>()
            {
                new GetDiscountViewModel(){Id = 1, Name = "1", CreatedAt = DateTime.Now, Reduction = 0.1},
            new GetDiscountViewModel(){Id = 2, Name = "2", CreatedAt = DateTime.Now, Reduction = 0.2},
            new GetDiscountViewModel(){Id = 3, Name = "3", CreatedAt = DateTime.Now, Reduction = 0.3},
            new GetDiscountViewModel(){Id = 4, Name = "4", CreatedAt = DateTime.Now, Reduction = 0.4},
            new GetDiscountViewModel(){Id = 5, Name = "5", CreatedAt = DateTime.Now, Reduction = 0.5},
            new GetDiscountViewModel(){Id = 6, Name = "6", CreatedAt = DateTime.Now, Reduction = 0.6},
            new GetDiscountViewModel(){Id = 7, Name = "7", CreatedAt = DateTime.Now, Reduction = 0.7},
            new GetDiscountViewModel(){Id = 8, Name = "8", CreatedAt = DateTime.Now, Reduction = 0.8},
            new GetDiscountViewModel(){Id = 9, Name = "9", CreatedAt = DateTime.Now, Reduction = 0.9},
            new GetDiscountViewModel(){Id = 10, Name = "10", CreatedAt = DateTime.Now, Reduction = 0.10},
            new GetDiscountViewModel(){Id = 11, Name = "11", CreatedAt = DateTime.Now, Reduction = 0.11},
            new GetDiscountViewModel(){Id = 12, Name = "12", CreatedAt = DateTime.Now, Reduction = 0.12},
        };
            if (viewModel.FilterRequests.Any())
            {
                data = data.Where(item => item.Name.Contains(viewModel.FilterRequests.FirstOrDefault().FilterQuery)).ToList();
            }

            return Ok(new ApiResultViewModel<GetDiscountViewModel>()
            {
                Data = data
                .Skip(viewModel.PageIndex*viewModel.PageSize)
                .Take(viewModel.PageSize)
                .ToList(),
                TotalCount = data.Count,
            });
        }
    }
}
