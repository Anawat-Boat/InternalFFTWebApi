using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCoreTraining.Interfaces;
using InternalWebApi.Database;
using InternalWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InternalWebApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        //ctor  create constructor
        public DatabaseContext databaseContext { get; }
        public EmployeeService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await databaseContext.Employees
                        .OrderByDescending(x => x.EmployeeId)
                        .ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await databaseContext.Employees
                        .SingleOrDefaultAsync(x => x.EmployeeId == id);
            // SingleOrDefaultAsync 1 record only (more than 1 return null)
        }
        public async Task<IEnumerable<Employee>> Search(string employeeCode)
        {
            return await databaseContext.Employees
                        .Where(p => p.EmployeeCode.ToLower().Contains(employeeCode.ToLower()))
                        .ToListAsync();
        }

        public async Task Insert(Employee employee)
        {
            databaseContext.Employees.Add(employee);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            databaseContext.Employees.Update(employee);
            await databaseContext.SaveChangesAsync();
        }
        public async Task Delete(Employee employee)
        {
            databaseContext.Employees.Remove(employee);
            await databaseContext.SaveChangesAsync();
        }

    }
}