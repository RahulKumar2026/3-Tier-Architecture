using DataLayer.Data;
using DataLayer.Models;
using DataLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace DataLayer.Repository
{
    public class GetEmployeesDataAccess : IGetEmployeesDataAccess
    {
        private readonly AppDbContext _dbcontext;
        private readonly IDistributedCache _cache;

        public GetEmployeesDataAccess(AppDbContext dbcontext, IDistributedCache cache) 
        {
            _dbcontext = dbcontext;
            _cache = cache;
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
        public async Task<EmployeeDepartmentView> GetEmployeesByIdAsyncDataLayer(int id)
        {
            try
            {
                var key = $"user-{id}";
                var cachedResult = await _cache.GetStringAsync(key);
                if (cachedResult is not null)
                {
                    return JsonSerializer.Deserialize<EmployeeDepartmentView>(cachedResult) ?? new EmployeeDepartmentView();
                }
                var dbResult = await _dbcontext.EmployeeDepartmentViews
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.EmployeeId == id);
                if (dbResult is null)
                {
                    return new EmployeeDepartmentView();
                }
                var json = JsonSerializer.Serialize(dbResult);

                await _cache.SetStringAsync(key,json, new DistributedCacheEntryOptions
                {
                   AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                });
                return dbResult;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving employee by ID: {ex.Message}", ex);
            }
        }
    }
}
