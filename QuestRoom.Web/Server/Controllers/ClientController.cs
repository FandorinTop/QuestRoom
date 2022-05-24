using Microsoft.AspNetCore.Mvc;
using QuestRoom.Interfaces.Services;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.Client.Request;

namespace QuestRoom.Web.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        IClientService _ClientService;

        public ClientController(IClientService ClientService)
        {
            _ClientService = ClientService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientViewModel viewModel)
        {
            var id = await _ClientService.Create(viewModel);

            return Ok(id.ToString());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var CourseViewModel = await _ClientService.Get(id);

            return Ok(CourseViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateClientViewModel viewModel)
        {
            await _ClientService.Update(viewModel);

            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> GetApiResponce(GetApiBodyRequest viewModel)
        {
            var responce = await _ClientService.GetAll(viewModel.PageIndex, viewModel.PageSize, viewModel.FilterRequests, viewModel.SortingRequests);

            return Ok(responce);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _ClientService.Delete(id);

            return Ok();
        }
    }
}
