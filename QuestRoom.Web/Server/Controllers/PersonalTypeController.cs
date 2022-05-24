using Microsoft.AspNetCore.Mvc;
using QuestRoom.Interfaces.Services;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.PersonalType.Request;

namespace QuestRoom.Web.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonalTypeController : ControllerBase
    {
        IPersonalTypeService _PersonalTypeService;

        public PersonalTypeController(IPersonalTypeService PersonalTypeService)
        {
            _PersonalTypeService = PersonalTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePersonalTypeViewModel viewModel)
        {
            var id = await _PersonalTypeService.Create(viewModel);

            return Ok(id.ToString());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var CourseViewModel = await _PersonalTypeService.Get(id);

            return Ok(CourseViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePersonalTypeViewModel viewModel)
        {
            await _PersonalTypeService.Update(viewModel);

            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> GetApiResponce(GetApiBodyRequest viewModel)
        {
            var responce = await _PersonalTypeService.GetAll(viewModel.PageIndex, viewModel.PageSize, viewModel.FilterRequests, viewModel.SortingRequests);

            return Ok(responce);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _PersonalTypeService.Delete(id);

            return Ok();
        }
    }
}
