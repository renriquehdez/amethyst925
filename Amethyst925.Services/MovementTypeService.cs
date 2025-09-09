using Amethyst925.Core.Entities;
using Amethyst925.Data;
using Microsoft.EntityFrameworkCore;

namespace Amethyst925.Services
{
    public class MovementTypeService : ICatalogService<MovementType, string>
    {
        private readonly AppDbContext _context;

        public MovementTypeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovementType>> GetAllAsync()
        {
            return await _context.MovementTypes.ToListAsync();
        }

        public async Task<MovementType?> GetByIdAsync(string id)
        {
            return await _context.MovementTypes.FindAsync(id);
        }

        public async Task<MovementType> CreateAsync(MovementType movementType)
        {
            if (await GetByIdAsync(movementType.Id) is null)
                _context.MovementTypes.Add(movementType);
            else
                _context.Entry(movementType).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return movementType;
        }

        public async Task<MovementType> UpdateAsync(MovementType movementType)
        {
            _context.Entry(movementType).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return movementType;
        }

        public async Task DeleteAsync(string id)
        {
            var movementType = await _context.MovementTypes.FindAsync(id);

            if (movementType != null)
            {
                _context.MovementTypes.Remove(movementType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
