using Microsoft.EntityFrameworkCore;

namespace AuthorizationMicroservice.Models
{
    public class AuthorizationDbContext:DbContext
    {
        private readonly IConfiguration _configuration;
        public AuthorizationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString
                ("SQLServerIdentityBase"));
        }
    }
}
