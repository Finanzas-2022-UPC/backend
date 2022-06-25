using FinanzasGrupo2API.Users.Domain.Repositories;
using FinanzasGrupo2API.Users.Domain.Services;

namespace FinanzasGrupo2API.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IProfileRepository profileRepository, IUnitOfWork unitOfWork, IMapper mapper, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var user = await _userRepository.FindByUsernameAsync(request.Username);
            //Validate
            if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect");



            //Authentication successful
            var response = _mapper.Map<AuthenticateResponse>(user);

            response.Token = _jwtHandler.GenerateToken(user);

            return response;
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            //Validate
            if (_userRepository.ExistsByUsername(request.Username))
                throw new AppException($"Username {request.Username} is already taken.");

            //Map request to User object
            var user = _mapper.Map<User>(request);


            //Has password
            user.PasswordHash = BCryptNet.HashPassword(request.Password);

            //Save User
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                var profile = new Profile();
                profile.UserId = user.Id;
                profile.GamingLevel = EGamingLevel.Newbie;
                profile.IsStreamer = true;

                await _profileRepository.AddAsync(profile);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while saving the user: {user}");
            }
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await _userRepository.FindByIdAsync(userId);
        }

        public async Task<User> ListByUserUsernameAsync(int userId)
        {
            return await _userRepository.FindByIdAsync(userId);
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            //Validate Username

            var existingUsername = await _userRepository.FindByUsernameAsync(user.Username);
            if (existingUsername != null)
                return new UserResponse("Username already exists.");

            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred while saving the user: {e.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            //Validate Id
            var existingUserById = await _userRepository.FindByIdAsync(id);

            if (existingUserById == null)
                return new UserResponse("User not found.");

            //Validate Username
            var existingUserByUsername = await _userRepository.FindByUsernameAsync(user.Username);
            if (existingUserByUsername != null && existingUserByUsername.Id != id)
                return new UserResponse("Username already used.");

            //Validate Email
            var existingUserByEmail = await _userRepository.FindByEmailAsync(user.Email);
            if (existingUserByEmail != null && existingUserByEmail.Id != id)
                return new UserResponse("Email already used.");

            existingUserById.Email = user.Email;
            existingUserById.Username = user.Username;
            existingUserById.Premium = user.Premium;

            try
            {
                _userRepository.Update(existingUserById);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUserById);

            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred while updating the user: {e.Message}");
            }

        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            //Validate User Id
            var existingUser = await _userRepository.FindByIdAsync(id);

            if (existingUser == null)
                return new UserResponse("User not found.");

            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);

            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred while deleting the user: {e.Message}");
            }
        }
    }
}
