using AuthorizationMicroservice.DTO;
using AuthorizationMicroservice.Mapping;
using AuthorizationMicroservice.Models;
using AuthorizationMicroservice.Repository;

namespace AuthorizationMicroservice.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUserMapper<User, IdentityDto,
            ProfileDto> _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;
        public UserService(IUserRepository repository,
            IUserMapper<User,IdentityDto,ProfileDto> mapper,
            IPasswordHasher passwordHasher,
            IJwtProvider jwtProvider)
        {
            _repository = repository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> Login(string email,string password)
        {

            var user = await _repository.GetByEmail(email);
            var result = _passwordHasher.Verify(password, user.Password);
            if (result == false) throw new Exception("Failed to login");
            var token = _jwtProvider.GenerateToken(user);
            return token;
        }

        public async Task<ProfileDto> GetByEmail(string email)
        {
            var user=await _repository.GetByEmail(email);
            return _mapper.ProfileMap(user);
        }

        public async Task<ProfileDto> GetById(long id)
        {
            var user = await _repository.GetById(id);
            return _mapper.ProfileMap(user);
        }

        public async Task Registry(IdentityDto identityDto)
        {
            if(await _repository.GetByEmail(identityDto.Email)!=null)
                throw new Exception("User is already registered");
            var hashedPassword = _passwordHasher.Generate(identityDto.Password);
            identityDto.Password = hashedPassword;
            await _repository.Add(_mapper.Map(identityDto));
        }
    }
}
