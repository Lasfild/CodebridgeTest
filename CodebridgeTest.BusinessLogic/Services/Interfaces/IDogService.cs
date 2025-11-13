using CodebridgeTest.DataAccess.Models;

namespace CodebridgeTest.BusinessLogic.Services.Interfaces
{
    public interface IDogService
    {
        Task<IEnumerable<Dog>> GetDogsAsync(string? attribute, string? order, int pageNumber, int pageSize);
        Task<(bool Success, string Message)> CreateDogAsync(Dog dog);
    }
}
