using Microsoft.AspNetCore.Mvc;
using ModelsApi.Models.State;
using ModelsApi.Models;
using ServicesApi.Services.InterfacesApi;
using ModelsApi.Models.Position;

namespace Api.Controllers
{
    [Route("position")]
    public class PositionController : Controller
    {
        private readonly IApiPosition _service;
        public PositionController(IApiPosition service) => _service = service;

        [HttpGet]
        [Route("getPositionAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ModelApiResponse getPositionAll()
        {
            ModelApiResponse ApiResponse = new ModelApiResponse();

            return ApiResponse = _service.getPositions();
        }

        [HttpPost]
        [Route("savePosition")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ModelApiResponse savePosition([FromBody] Positions position)
        {
            ModelApiResponse ApiResponse = new ModelApiResponse();

            return ApiResponse = _service.insertPosition(position);

        }

        [HttpPost]
        [Route("updatePosition")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ModelApiResponse updatePosition([FromBody] Positions position)
        {
            ModelApiResponse ApiResponse = new ModelApiResponse();

            return ApiResponse = _service.updatePosition(position);

        }

        [HttpPost]
        [Route("deletePosition")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ModelApiResponse deletePosition([FromBody] Positions position)
        {
            ModelApiResponse ApiResponse = new ModelApiResponse();

            return ApiResponse = _service.deletePosition(position);

        }
    }
}
