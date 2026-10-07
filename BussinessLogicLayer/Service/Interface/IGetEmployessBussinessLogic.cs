using BussinessLogicLayer.DTOs;
using DataLayer.Models;

namespace BusinessLogicLayer.Service.Interface
{
    public interface IGetEmployeesBusinessLogic
    {
        Task<List<GetEmployeeDto>> GetEmployeesAsync();
        Task<EmployeeDepartmentView> GetEmployeesByIdAsync(int id);
    }
}