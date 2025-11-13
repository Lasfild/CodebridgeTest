using CodebridgeTest.DataAccess.Models;

namespace CodebridgeTest.DataAccess.Repositories.Interfaces
{
    public interface IDogRepository
    {
        Task<IEnumerable<Dog>> GetAllAsync(string? attribute, string? order, int pageNumber, int pageSize);
        Task<Dog?> GetByNameAsync(string name);
        Task AddAsync(Dog dog);
        Task SaveChangesAsync();
    }
}
