using AuthorizationMicroservice.DTO;
using AuthorizationMicroservice.Models;

namespace AuthorizationMicroservice.Mapping
{
    public class UserMap : IUserMapper<User, IdentityDto, ProfileDto>
    {
        public IdentityDto IdentityMap(User model)
        {
            return new IdentityDto
            {
                Email = model.Email,
                Password = model.Password,
                FirstName = model.FirstName,
                SurName=model.Surname
            };
        }

        public User Map(IdentityDto dto)
        {
            return new User
            {
                Email = dto.Email,
                Password = dto.Password,
                FirstName = dto.FirstName,
                Surname=dto.SurName
            };
        }

        public User Map(ProfileDto dto)
        {
            return new User
            {
                Email = dto.Email,
                Nickname = dto.Nickname,
                PhoneNumber = dto.PhoneNumber,
                Surname = dto.Surname,
                //BirthDate = dto.BirthDate,
                FirstName = dto.FirstName,
                ImagePathName = dto.ImagePathName,
                IsEmailConfirmed = dto.IsEmailConfirmed,
                IsPhoneConfirmed = dto.IsPhoneConfirmed
            };
        }

        public ProfileDto ProfileMap(User model)
        {
            return new ProfileDto
            {
                Email = model.Email,
                FirstName = model.FirstName,
                Surname = model.Surname,
                Nickname = model.Nickname,
                //BirthDate = model.BirthDate,
                PhoneNumber = model.PhoneNumber,
                IsPhoneConfirmed = model.IsPhoneConfirmed,
                IsEmailConfirmed = model.IsEmailConfirmed,
                ImagePathName = model.ImagePathName
            };
        }
    }
}
