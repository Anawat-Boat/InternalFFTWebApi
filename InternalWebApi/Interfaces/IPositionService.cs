using System.Collections.Generic;
using System.Threading.Tasks;
using InternalWebApi.Models;

namespace ASPNETCoreTraining.Interfaces
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> GetAll();
        Task<Position> GetById(int id);
        Task Insert(Position position);
        Task Update(Position position);
        Task Delete(Position position);
        Task<IEnumerable<Position>> Search(string positionName);
    }
}