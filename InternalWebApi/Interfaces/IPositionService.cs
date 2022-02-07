using System.Collections.Generic;
using System.Threading.Tasks;
using InternalWebApi.Models;

namespace ASPNETCoreTraining.Interfaces
{
    public interface IPositionService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T dataItem);
        Task Update(T dataItem);
        Task Delete(T dataItem);
        Task<IEnumerable<T>> Search(string name);
    }
}