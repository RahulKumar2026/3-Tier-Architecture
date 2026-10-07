using DataLayer.Models;

namespace DataLayer.Repository.Interface
{
    public interface IGetEmployeesDataAccess
    {
        public Task<List<EmployeeDepartmentView>> GetEmployeesAsyncDataLayer();
        public Task<EmployeeDepartmentView> GetEmployeesByIdAsyncDataLayer(int id);
    }
}
