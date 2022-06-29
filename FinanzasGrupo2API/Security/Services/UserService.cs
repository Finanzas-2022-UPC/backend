using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinanzasGrupo2API.Security.Authorization.Handlers.Interfaces;
using FinanzasGrupo2API.Security.Domain.Models;
using FinanzasGrupo2API.Security.Domain.Repositories;
using FinanzasGrupo2API.Security.Domain.Services;
using FinanzasGrupo2API.Security.Domain.Services.Communication;
using FinanzasGrupo2API.Security.Exceptions;
using FinanzasGrupo2API.Security.Resources;
using FinanzasGrupo2API.Shared.Domain.Repositories;
using FinanzasGrupo2API.Shared.Extensions;
using BCryptNet = BCrypt.Net.BCrypt;


namespace FinanzasGrupo2API.Security.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var user = await _userRepository.FindByEmailAsync(request.email);

            //Validate
            if (user == null || !BCryptNet.Verify(request.password, user.password_hash))
                throw new AppException("Username or password is incorrect");
            
            
            
            //Authentication successful
            var response = _mapper.Map<AuthenticateResponse>(user);

            response.token = _jwtHandler.GenerateToken(user);

            return response;
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            //Validate
            if (_userRepository.ExistsByEmail(request.email))
                throw new AppException($"Username {request.email} is already taken.");
            
            //Map request to User object
            var user = _mapper.Map<Usuario>(request);
            
            
            //Hash password
            user.password_hash = BCryptNet.HashPassword(request.password);
            
            //Save User
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while saving the user: {user}");
            }
        }

        public async Task<IEnumerable<Usuario>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<Usuario> GetByIdAsync(int userId)
        {
            return await _userRepository.FindByIdAsync(userId);
        }
        
        public async Task<Usuario> GetByUserEmailAsync(string email)
        {
            return await _userRepository.FindByEmailAsync(email);
        }

        public async Task<UsuarioResponse> SaveAsync(Usuario user)
        {
            //Validate Username
            
            var existingUsername = await _userRepository.FindByEmailAsync(user.email);
            if (existingUsername != null)
                return new UsuarioResponse("Username already exists.");

            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UsuarioResponse(user);
            }
            catch (Exception e)
            {
                return new UsuarioResponse($"An error occurred while saving the user: {e.Message}");
            }
        }

        public async Task<UsuarioResponse> UpdateAsync(int id, SaveUsuarioResource user)
        {
            //Validate Id
            var existingUserById = await _userRepository.FindByIdAsync(id);

            if (existingUserById == null)
                return new UsuarioResponse("User not found.");
          
            //Validate Email
            var existingUserByEmail = await _userRepository.FindByEmailAsync(user.email);
            if (existingUserByEmail != null && existingUserByEmail.id != id)
                return new UsuarioResponse("Email already used.");

            existingUserById.email = user.email;
            existingUserById.nombre = user.nombre;
            existingUserById.password_hash = BCryptNet.HashPassword(user.password);

            try
            {
                _userRepository.Update(existingUserById);
                await _unitOfWork.CompleteAsync();

                return new UsuarioResponse(existingUserById);

            }
            catch (Exception e)
            {
                return new UsuarioResponse($"An error occurred while updating the user: {e.Message}");
            }

        }

        public async Task<UsuarioResponse> DeleteAsync(int id)
        {
            //Validate User Id
            var existingUser = await _userRepository.FindByIdAsync(id);

            if (existingUser == null)
                return new UsuarioResponse("User not found.");

            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UsuarioResponse(existingUser);

            }
            catch (Exception e)
            {
                return new UsuarioResponse($"An error occurred while deleting the user: {e.Message}");
            }
        }
    }
}