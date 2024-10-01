
using AuthorizationMicroservice.DTO;
using AuthorizationMicroservice.Mapping;
using AuthorizationMicroservice.Models;
using AuthorizationMicroservice.Repository;
using AuthorizationMicroservice.Service;

namespace AuthorizationMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            builder.Services.AddScoped<AuthorizationDbContext>();

            builder.Services.AddTransient<IUserMapper<User,
                IdentityDto, ProfileDto>, UserMap>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IUserService, UserService>();

            builder.Services.AddScoped<IJwtProvider, JwtProvider>();
            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

            builder.Services.Configure<JwtOptions>(builder
                .Configuration.GetSection(nameof(JwtOptions)));

            var app = builder.Build();

            using var scope=app.Services.CreateScope();
            using var dbContext = scope.ServiceProvider
                .GetRequiredService<AuthorizationDbContext>();
            dbContext.Database.EnsureCreatedAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();
            app.UseAuthorization();

            app.Run();
        }
    }
}
