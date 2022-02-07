using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCoreTraining.Database;
using ASPNETCoreTraining.Interfaces;
using ASPNETCoreTraining.Models;

using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreTraining.Services
{
    public class DepartmentService : IDepartmentService
    {
        //ctor  create constructor
        public DatabaseContext databaseContext { get; }
        public DepartmentService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<IEnumerable<Department>> GetAll()
        {
            return await databaseContext.Departments
                        .OrderByDescending(x => x.DepartmentId)
                        .ToListAsync();
        }

        public async Task<Department> GetById(int id)
        {
            return await databaseContext.Departments
                        .SingleOrDefaultAsync(x => x.DepartmentId == id); // SingleOrDefaultAsync 1 record only (more than 1 return null)
        }

        public async Task Insert(Department department)
        {
            databaseContext.Departments.Add(department);
            await databaseContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Department>> Search(string name)
        {
            return await databaseContext.Departments
                        .Where(p => p.DepartmentName.ToLower().Contains(name.ToLower()))
                        .ToListAsync();
        }

        public async Task Update(Department department)
        {
            databaseContext.Departments.Update(department);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(Department department)
        {
            databaseContext.Departments.Remove(department);
            await databaseContext.SaveChangesAsync();
        }
    }
}