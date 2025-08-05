namespace Amethyst925.Services;

using Amethyst925.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBranchService
{
    Task<IEnumerable<Branch>> GetAllAsync();
    Task<Branch?> GetByIdAsync(int id);
    Task<Branch> CreateAsync(Branch branch);
    Task<Branch> UpdateAsync(Branch branch);
    Task DeleteAsync(int id, string username);
}
