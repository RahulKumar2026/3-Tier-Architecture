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
        [HttpGet]
        [Route("get-Employee-by-Id/{id}")]
        public async Task<IActionResult> GetEmployeesByIdAsync(int id)
        {
            try
            {
                var employee = await _getEmployeesBusinessLogic.GetEmployeesByIdAsync(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
