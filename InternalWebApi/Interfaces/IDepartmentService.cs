using System.Collections.Generic;
using System.Threading.Tasks;
using InternalWebApi.Models;

namespace InternalWebApi.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(int id);
        Task Insert(Department department);
        Task Update(Department department);
        Task Delete(Department department);
        Task<IEnumerable<Department>> Search(string name);
    }
}