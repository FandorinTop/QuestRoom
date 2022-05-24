using Microsoft.AspNetCore.Mvc;
using QuestRoom.Interfaces.Services;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.QuestActor.Request;

namespace QuestRoom.Web.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestActorController : ControllerBase
    {
        IQuestActorService _QuestActorService;

        public QuestActorController(IQuestActorService QuestActorService)
        {
            _QuestActorService = QuestActorService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestActorViewModel viewModel)
        {
            var id = await _QuestActorService.Create(viewModel);

            return Ok(id.ToString());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var CourseViewModel = await _QuestActorService.Get(id);

            return Ok(CourseViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateQuestActorViewModel viewModel)
        {
            await _QuestActorService.Update(viewModel);

            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> GetApiResponce(GetApiBodyRequest viewModel)
        {
            var responce = await _QuestActorService.GetAll(viewModel.PageIndex, viewModel.PageSize, viewModel.FilterRequests, viewModel.SortingRequests);

            return Ok(responce);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _QuestActorService.Delete(id);

            return Ok();
        }
    }
}
