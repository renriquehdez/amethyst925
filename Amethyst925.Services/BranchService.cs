namespace Amethyst925.Services;

using Amethyst925.Core.Entities;
using Amethyst925.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BranchService : IBranchService
{
    private readonly AppDbContext _context;

    public BranchService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Branch>> GetAllAsync()
    {
        return await _context.Branches.ToListAsync();
    }

    public async Task<Branch?> GetByIdAsync(int id)
    {
        return await _context.Branches.FindAsync(id);
    }

    public async Task<Branch> CreateAsync(Branch branch)
    {
        if (GetByIdAsync(branch.Id) is null)
            _context.Branches.Add(branch);
        else
            _context.Entry(branch).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return branch;
    }

    public async Task<Branch> UpdateAsync(Branch branch)
    {
        _context.Entry(branch).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return branch;
    }

    public async Task DeleteAsync(int id)
    {
        var branch = await _context.Branches.FindAsync(id);
        if (branch != null)
        {
            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();
        }
    }
}
