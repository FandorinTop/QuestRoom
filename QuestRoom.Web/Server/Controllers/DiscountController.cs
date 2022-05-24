using Microsoft.AspNetCore.Mvc;
using QuestRoom.Interfaces.Services;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.Discount.Request;
using QuestRoom.ViewModel.Discount.Responce;
using System.Linq;

namespace QuestRoom.Web.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDiscountViewModel viewModel)
        {
            var id = await _discountService.Create(viewModel);

            return Ok(id.ToString());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var CourseViewModel = await _discountService.Get(id);

            return Ok(CourseViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDiscountViewModel viewModel)
        {
            await _discountService.Update(viewModel);

            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> GetApiResponce(GetApiBodyRequest viewModel)
        {
            var responce = await _discountService.GetAll(viewModel.PageIndex, viewModel.PageSize, viewModel.FilterRequests, viewModel.SortingRequests);

            return Ok(responce);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _discountService.Delete(id);

            return Ok();
        }
    }
}
