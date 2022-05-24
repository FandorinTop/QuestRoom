using Microsoft.AspNetCore.Mvc;
using QuestRoom.Interfaces.Services;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.Personal.Request;

namespace QuestRoom.Web.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        IPersonalService _PersonalService;

        public PersonalController(IPersonalService PersonalService)
        {
            _PersonalService = PersonalService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePersonalViewModel viewModel)
        {
            var id = await _PersonalService.Create(viewModel);

            return Ok(id.ToString());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var CourseViewModel = await _PersonalService.Get(id);

            return Ok(CourseViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePersonalViewModel viewModel)
        {
            await _PersonalService.Update(viewModel);

            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> GetApiResponce(GetApiBodyRequest viewModel)
        {
            var responce = await _PersonalService.GetAll(viewModel.PageIndex, viewModel.PageSize, viewModel.FilterRequests, viewModel.SortingRequests);

            return Ok(responce);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _PersonalService.Delete(id);

            return Ok();
        }
    }
}
