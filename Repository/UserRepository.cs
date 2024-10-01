using AuthorizationMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationMicroservice.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly AuthorizationDbContext _context;
        public UserRepository(AuthorizationDbContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            await _context.Users
                .AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var user=await GetById(id);
            user.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users
                .Where(u=>!u.IsDeleted &&
                u.Email==email)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetById(long id)
        {
            return await _context.Users
                .Where(u => !u.IsDeleted
                && u.Id == id)
                .FirstAsync();
        }

        public async Task Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
