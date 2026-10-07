using BusinessLogicLayer.Service.Interface;
using BussinessLogicLayer.DTOs;
using DataLayer.Repository.Interface;
namespace BusinessLogicLayer.Service
{
    public class GetEmployessBussinessLogic : IGetEmployeesBusinessLogic
    {
        private readonly IGetEmployeesDataAccess _getEmployessDataAccess;
        public GetEmployessBussinessLogic(IGetEmployeesDataAccess getEmployessDataAccess)
        {
            _getEmployessDataAccess = getEmployessDataAccess;
        }
        public async Task<List<GetEmployeeDto>> GetEmployeesAsync() 
        {
            try
            {
                // Call the data access layer to get the employees
                var employees = await _getEmployessDataAccess.GetEmployeesAsyncDataLayer();
                //Vailldate the employees list
                if (employees == null || employees.Count == 0)
                {
                    return new List<GetEmployeeDto>();
                }
                //Projection to DTOs if necessary (assuming the data access layer returns a compatible type)
                var result = employees.Select(e => new GetEmployeeDto
                {
                    EmployeeName = e.EmployeeName,
                    Salary = e.Salary,
                    DepartmentId = e.DepartmentId,
                    DepartmentName = e.DepartmentName
                }).ToList();

                return result;
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error retrieving employees: {ex.Message}", ex);
            }
        }
    }
}
