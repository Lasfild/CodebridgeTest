using CodebridgeTest.DataAccess.Context;
using CodebridgeTest.DataAccess.Models;
using CodebridgeTest.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodebridgeTest.DataAccess.Repositories
{
    public class DogRepository : IDogRepository
    {
        private readonly DogsContext _context;

        public DogRepository(DogsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dog>> GetAllAsync(string? attribute, string? order, int pageNumber, int pageSize)
        {
            IQueryable<Dog> dogs = _context.Dogs;

            if (!string.IsNullOrEmpty(attribute))
            {
                dogs = attribute.ToLower() switch
                {
                    "name" => order == "desc" ? dogs.OrderByDescending(d => d.Name) : dogs.OrderBy(d => d.Name),
                    "color" => order == "desc" ? dogs.OrderByDescending(d => d.Color) : dogs.OrderBy(d => d.Color),
                    "tail_length" => order == "desc" ? dogs.OrderByDescending(d => d.Tail_Length) : dogs.OrderBy(d => d.Tail_Length),
                    "weight" => order == "desc" ? dogs.OrderByDescending(d => d.Weight) : dogs.OrderBy(d => d.Weight),
                    _ => dogs
                };
            }

            dogs = dogs.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return await dogs.ToListAsync();
        }

        public async Task<Dog?> GetByNameAsync(string name)
        {
            return await _context.Dogs.FirstOrDefaultAsync(d => d.Name == name);
        }

        public async Task AddAsync(Dog dog)
        {
            await _context.Dogs.AddAsync(dog);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
