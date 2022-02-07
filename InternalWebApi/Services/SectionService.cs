using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCoreTraining.Database;
using ASPNETCoreTraining.Interfaces;
using ASPNETCoreTraining.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreTraining.Services
{
    public class SectionService : ISectionService
    {
        public readonly DatabaseContext databaseContext;
        public SectionService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Section>> GetAll()
        {
            return await databaseContext.Sections.Include(x => x.Department)
                        .OrderByDescending(x => x.SectionId)
                        .ToListAsync();
        }

        public async Task<Section> GetById(int id)
        {
            return await databaseContext.Sections.Include(x => x.Department)
                        .SingleOrDefaultAsync(x => x.SectionId == id);
        }
        public async Task<IEnumerable<Section>> Search(string name)
        {
            return await databaseContext.Sections.Include(x => x.Department)
                        .Where(x => x.SectionName.ToLower().Contains(name.ToLower()))
                        .ToListAsync();
        }
        public async Task Insert(Section section)
        {
            databaseContext.Sections.Add(section);
            await databaseContext.SaveChangesAsync();
        }
        public async Task Update(Section section)
        {
            databaseContext.Sections.Update(section);
            await databaseContext.SaveChangesAsync();
        }
        public async Task Delete(Section section)
        {
            databaseContext.Sections.Remove(section);
            await databaseContext.SaveChangesAsync();
        }
    }
}