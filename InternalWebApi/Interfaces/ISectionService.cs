using System.Collections.Generic;
using System.Threading.Tasks;
using InternalWebApi.Models;

namespace ASPNETCoreTraining.Interfaces
{
    public interface ISectionService
    {
        Task<IEnumerable<Section>> GetAll();
        Task<Section> GetById(int id);
        Task Insert(Section section);
        Task Update(Section section);
        Task Delete(Section section);
        Task<IEnumerable<Section>> Search(string name);
    }
}