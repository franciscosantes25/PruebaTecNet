using Microsoft.AspNetCore.Mvc;
using ModelsApi.Models;
using ModelsApi.Models.Employee;
using ModelsApi.Models.State;
using ServicesApi.Services.InterfacesApi;

namespace Api.Controllers
{
    [Route("state")]
    public class StateController : Controller
    {
        private readonly IApiState _service;
        public StateController(IApiState service) => _service = service;

        [HttpGet]
        [Route("getStateAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ModelApiResponse getStateAll()
        {
            ModelApiResponse ApiResponse = new ModelApiResponse();

            return ApiResponse = _service.getStates();
        }

        [HttpPost]
        [Route("saveState")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ModelApiResponse saveState([FromBody] States state)
        {
            ModelApiResponse ApiResponse = new ModelApiResponse();

            return ApiResponse = _service.insertState(state);

        }

        [HttpPost]
        [Route("updateState")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ModelApiResponse updateState([FromBody] States state)
        {
            ModelApiResponse ApiResponse = new ModelApiResponse();

            return ApiResponse = _service.updateState(state);

        }

        [HttpPost]
        [Route("deleteState")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ModelApiResponse deleteState([FromBody] States state)
        {
            ModelApiResponse ApiResponse = new ModelApiResponse();

            return ApiResponse = _service.deleteState(state);

        }
    }
}
