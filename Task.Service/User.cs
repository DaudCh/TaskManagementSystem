using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TaskI.Core.DTOS.User;
using TaskI.Core.Entities;
using TaskI.Core.Repository;

namespace TaskI.Services
{
    public class User
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // Add a new user
        public async Task AddUserAsync(UserCreateDTO userDto, CancellationToken cancellationToken = default)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddUserAsync(user, cancellationToken);
        }

        // Update user details
        public async Task UpdateUserAsync(UserUpdateDTO userDto, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetUserByIdAsync(userDto.Id, cancellationToken);
            if (user != null)
            {
                _mapper.Map(userDto, user);
                await _userRepository.UpdateUserAsync(user, cancellationToken);
            }
        }

        // Get user by ID
        public async Task<UserDTO> GetUserByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetUserByIdAsync(id, cancellationToken);
            return _mapper.Map<UserDTO>(user);
        }

        // Get all users
        public async Task<List<UserDTO>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            var users = await _userRepository.GetAllUsersAsync(cancellationToken);
            return _mapper.Map<List<UserDTO>>(users);
        }

        // Delete user by ID
        public async Task DeleteUserAsync(UserDeleteDTO userDto, CancellationToken cancellationToken = default)
        {
            await _userRepository.DeleteUserAsync(userDto.Id, cancellationToken);
        }

        // Authenticate user (Login)
        public async Task<UserDTO> AuthenticateUserAsync(UserLoginDTO loginDto, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.AuthenticateUserAsync(loginDto.Email, loginDto.Password, cancellationToken);
            return _mapper.Map<UserDTO>(user);
        }

        // Get users by role
        public async Task<List<UserDTO>> GetUsersByRoleAsync(string role, CancellationToken cancellationToken = default)
        {
            var users = await _userRepository.GetUsersByRoleAsync(role, cancellationToken);
            return _mapper.Map<List<UserDTO>>(users);
        }
    }
}