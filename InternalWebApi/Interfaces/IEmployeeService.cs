using System.Collections.Generic;
using System.Threading.Tasks;
using InternalWebApi.Models;

namespace ASPNETCoreTraining.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task Insert(Employee employee);
        Task Update(Employee employee);
        Task Delete(Employee employee);
        Task<IEnumerable<Employee>> Search(string employeeName);
    }
}