namespace Amethyst925.Services
{
    public interface ICatalogService<T, TKey>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(TKey id);
        Task<T> CreateAsync(T t);
        Task<T> UpdateAsync(T t);
        Task DeleteAsync(TKey id);
    }
}
