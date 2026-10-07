using DataLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using DataLayer.Data;

namespace DataLayer.Repository
{
    public class GetEmployeesDataAccess : IGetEmployeesDataAccess
    {
        private readonly AppDbContext _dbcontext;
        public GetEmployeesDataAccess(AppDbContext dbcontext) 
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<EmployeeDepartmentView>> GetEmployeesAsyncDataLayer() 
        {
            try
            {
                var employees = await _dbcontext.EmployeeDepartmentViews.AsNoTracking().ToListAsync();
                return employees;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving employees: {ex.Message}", ex);
            }
        }
    }
}
