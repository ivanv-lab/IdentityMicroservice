using AuthorizationMicroservice.DTO;
using AuthorizationMicroservice.Models;

namespace AuthorizationMicroservice.Mapping
{
    public interface IUserMapper<Model,IdentityDto,ProfileDto>
    {
        public Model Map(IdentityDto dto);
        public Model Map(ProfileDto dto);
        public IdentityDto IdentityMap(Model model);
        public ProfileDto ProfileMap(Model model);
    }
}
