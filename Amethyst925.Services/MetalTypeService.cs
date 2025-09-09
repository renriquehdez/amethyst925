using Amethyst925.Core.Entities;
using Amethyst925.Data;
using Microsoft.EntityFrameworkCore;

namespace Amethyst925.Services
{
    public class MetalTypeService : ICatalogService<MetalType, int>
    {
        private readonly AppDbContext _context;

        public MetalTypeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MetalType>> GetAllAsync()
        {
            return await _context.MetalTypes.ToListAsync();
        }

        public async Task<MetalType?> GetByIdAsync(int id)
        {
            return await _context.MetalTypes.FindAsync(id);
        }

        public async Task<MetalType> CreateAsync(MetalType metalType)
        {
            if (GetByIdAsync(metalType.Id) is null)
                _context.MetalTypes.Add(metalType);
            else
                _context.Entry(metalType).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return metalType;
        }

        public async Task<MetalType> UpdateAsync(MetalType metalType)
        {
            _context.Entry(metalType).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return metalType;
        }

        public async Task DeleteAsync(int id)
        {
            var metalType = await _context.MetalTypes.FindAsync(id);
            if (metalType != null)
            {
                _context.MetalTypes.Remove(metalType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
