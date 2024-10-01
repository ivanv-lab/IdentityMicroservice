using AuthorizationMicroservice.DTO;

namespace AuthorizationMicroservice.Service
{
    public interface IUserService
    {
        public Task<ProfileDto> GetById(long id);
        public Task<ProfileDto> GetByEmail(string email);
        public Task<string> Login(string email, string password);
        public Task Registry(IdentityDto identityDto);
    }
}
