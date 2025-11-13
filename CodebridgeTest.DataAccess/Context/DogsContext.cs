using CodebridgeTest.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CodebridgeTest.DataAccess.Context
{
    public class DogsContext : DbContext
    {
        public DogsContext(DbContextOptions<DogsContext> options) : base(options) { }
        public DbSet<Dog> Dogs { get; set; } = null!;
    }
}
