using Microsoft.EntityFrameworkCore;
using PanteonApi.Domain.Entities;

namespace PanteonApi.Infrastructure.Repositories{
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<User> Users {get; set;}
    }
}