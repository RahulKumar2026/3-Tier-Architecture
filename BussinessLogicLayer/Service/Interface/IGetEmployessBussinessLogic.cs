using BussinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Service.Interface
{
    public interface IGetEmployeesBusinessLogic
    {
        Task<List<GetEmployeeDto>> GetEmployeesAsync();
    }
}