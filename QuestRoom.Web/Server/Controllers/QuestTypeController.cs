using Microsoft.AspNetCore.Mvc;
using QuestRoom.Interfaces.Services;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.QuestType.Request;

namespace QuestRoom.Web.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestTypeController : ControllerBase
    {
        IQuestTypeService _QuestTypeService;

        public QuestTypeController(IQuestTypeService QuestTypeService)
        {
            _QuestTypeService = QuestTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestTypeViewModel viewModel)
        {
            var id = await _QuestTypeService.Create(viewModel);

            return Ok(id.ToString());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var CourseViewModel = await _QuestTypeService.Get(id);

            return Ok(CourseViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateQuestTypeViewModel viewModel)
        {
            await _QuestTypeService.Update(viewModel);

            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> GetApiResponce(GetApiBodyRequest viewModel)
        {
            var responce = await _QuestTypeService.GetAll(viewModel.PageIndex, viewModel.PageSize, viewModel.FilterRequests, viewModel.SortingRequests);

            return Ok(responce);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _QuestTypeService.Delete(id);

            return Ok();
        }
    }
}
