using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCoreTraining.Interfaces;
using InternalWebApi.Database;
using InternalWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InternalWebApi.Services
{
    public class PositionService : IPositionService
    {
        public DatabaseContext databaseContext { get; }
        public PositionService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<IEnumerable<Position>> GetAll()
        {
            return await databaseContext.Positions
                        .OrderByDescending(x => x.PositionId)
                        .ToListAsync();
        }

        public async Task<Position> GetById(int id)
        {
            return await databaseContext.Positions
                        .SingleOrDefaultAsync(x => x.PositionId == id); // SingleOrDefaultAsync 1 record only (more than 1 return null)
        }

        public async Task<IEnumerable<Position>> Search(string positionName)
        {
            return await databaseContext.Positions
                        .Where(p => p.PositionName.ToLower().Contains(positionName.ToLower()))
                        .ToListAsync();
        }

        public async Task Insert(Position position)
        {
            databaseContext.Positions.Add(position);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Update(Position position)
        {
            databaseContext.Positions.Update(position);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(Position position)
        {
            databaseContext.Positions.Remove(position);
            await databaseContext.SaveChangesAsync();
        }
    }
}