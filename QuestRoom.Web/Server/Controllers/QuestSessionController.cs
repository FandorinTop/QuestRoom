using Microsoft.AspNetCore.Mvc;
using QuestRoom.Interfaces.Services;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.QuestSession.Request;

namespace QuestRoom.Web.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestSessionController : ControllerBase
    {
        IQuestSessionService _QuestSessionService;

        public QuestSessionController(IQuestSessionService QuestSessionService)
        {
            _QuestSessionService = QuestSessionService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestSessionViewModel viewModel)
        {
            var id = await _QuestSessionService.Create(viewModel);

            return Ok(id.ToString());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var CourseViewModel = await _QuestSessionService.Get(id);

            return Ok(CourseViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateQuestSessionViewModel viewModel)
        {
            await _QuestSessionService.Update(viewModel);

            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> GetApiResponce(GetApiBodyRequest viewModel)
        {
            var responce = await _QuestSessionService.GetAll(viewModel.PageIndex, viewModel.PageSize, viewModel.FilterRequests, viewModel.SortingRequests);

            return Ok(responce);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _QuestSessionService.Delete(id);

            return Ok();
        }
    }
}
