using CodebridgeTest.BusinessLogic.Services.Interfaces;
using CodebridgeTest.DataAccess.Models;
using CodebridgeTest.DataAccess.Repositories.Interfaces;


namespace CodebridgeTest.BusinessLogic.Services
{
    public class DogService : IDogService
    {
        private readonly IDogRepository _repo;

        public DogService(IDogRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Dog>> GetDogsAsync(string? attribute, string? order, int pageNumber, int pageSize)
        {
            return await _repo.GetAllAsync(attribute, order, pageNumber, pageSize);
        }

        public async Task<(bool Success, string Message)> CreateDogAsync(Dog dog)
        {
            if (dog.Tail_Length < 0 || dog.Weight < 0)
                return (false, "Tail length and weight must be non-negative.");

            var existing = await _repo.GetByNameAsync(dog.Name);
            if (existing != null)
                return (false, $"Dog with name '{dog.Name}' already exists.");

            await _repo.AddAsync(dog);
            await _repo.SaveChangesAsync();
            return (true, "Dog created successfully.");
        }
    }
}
