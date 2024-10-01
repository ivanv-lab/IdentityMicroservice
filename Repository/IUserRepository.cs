using AuthorizationMicroservice.Models;

namespace AuthorizationMicroservice.Repository
{
    public interface IUserRepository
    {
        public Task<User> GetById(long id);
        public Task<User> GetByEmail(string email);
        public Task Add(User user);
        public Task Update(User user);
        public Task Delete(long id);
    }
}
