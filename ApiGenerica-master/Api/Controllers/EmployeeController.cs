using Microsoft.AspNetCore.Mvc;
using ModelsApi.Models;
using ModelsApi.Models.Employee;
using ServicesApi.Services.InterfacesApi;

namespace Api.Controllers
{
    [Route("employee")]
    public class EmployeeController : Controller
    {
        private readonly IApiEmployee _service;
        public EmployeeController(IApiEmployee service) => _service = service;

        [HttpGet]
        [Route("getEmployeeAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ModelApiResponse getEmployeeAll()
        {
            ModelApiResponse ApiResponse = new ModelApiResponse();

            return ApiResponse = _service.getEmployees();

        }

        [HttpPost]
        [Route("saveEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ModelApiResponse saveEmployee([FromBody] Employees employee)
        {
            ModelApiResponse ApiResponse = new ModelApiResponse();

            return ApiResponse = _service.insertEmployee(employee);

        }

        [HttpPost]
        [Route("updateEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ModelApiResponse updateEmployee([FromBody] Employees employee)
        {
            ModelApiResponse ApiResponse = new ModelApiResponse();

            return ApiResponse = _service.updateEmployee(employee);

        }

        [HttpPost]
        [Route("deleteEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ModelApiResponse deleteEmployee([FromBody] Employees employee)
        {
            ModelApiResponse ApiResponse = new ModelApiResponse();

            return ApiResponse = _service.deleteEmployee(employee);

        }
    }
}
