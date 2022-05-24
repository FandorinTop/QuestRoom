using Microsoft.AspNetCore.Mvc;
using QuestRoom.Interfaces.Services;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.Type.Request;

namespace QuestRoom.Web.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestTypeNameTypeNameController : ControllerBase
    {
        IQuestTypeNameService _QuestTypeNameService;

        public QuestTypeNameTypeNameController(IQuestTypeNameService QuestTypeNameService)
        {
            _QuestTypeNameService = QuestTypeNameService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestTypeNameViewModel viewModel)
        {
            var id = await _QuestTypeNameService.Create(viewModel);

            return Ok(id.ToString());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var CourseViewModel = await _QuestTypeNameService.Get(id);

            return Ok(CourseViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateQuestTypeNameViewModel viewModel)
        {
            await _QuestTypeNameService.Update(viewModel);

            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> GetApiResponce(GetApiBodyRequest viewModel)
        {
            var responce = await _QuestTypeNameService.GetAll(viewModel.PageIndex, viewModel.PageSize, viewModel.FilterRequests, viewModel.SortingRequests);

            return Ok(responce);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _QuestTypeNameService.Delete(id);

            return Ok();
        }
    }
}
