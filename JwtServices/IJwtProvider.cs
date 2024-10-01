using AuthorizationMicroservice.Models;

namespace AuthorizationMicroservice.Service
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}