using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Service.Interface;

namespace PresentionLayer.Controllers
{
    [ApiController]
    [Route("api/Employee")]
    public class EmployeeController : ControllerBase
    {
        IGetEmployeesBusinessLogic _getEmployeesBusinessLogic;
        public EmployeeController(IGetEmployeesBusinessLogic getEmployeesBusinessLogic)
        {
            _getEmployeesBusinessLogic = getEmployeesBusinessLogic;
        }
        [HttpGet]
        [Route("get-Employees-with-Departments")]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            try
            {
                var employees = await _getEmployeesBusinessLogic.GetEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
