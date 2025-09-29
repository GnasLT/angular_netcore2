using MyAPI.Application.Abstraction;
using MyAPI.Application.DTO.Request;
using MyAPI.Application.DTO.Response;
using MyAPI.Domain.Entities;
using MyAPI.Domain.Repository;


namespace MyAPI.Application.Service
{
    public class AuthService : IAuthenService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionRepository _sessionRepository;

        public AuthService(IUserRepository userRepository, ISessionRepository sessionRepository)
        {
            _userRepository = userRepository;
            _sessionRepository = sessionRepository;
        }

        public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                return await Result<LoginResponse>.FailureResult("User not found");
            if (user.PasswordHash != request.Password)
                return await Result<LoginResponse>.FailureResult("Invalid credentials");

            LoginResponse lresponse = new LoginResponse()
            {
                Email = user.Email,
                Role = user.Role
            };
            return await Result<LoginResponse>.SuccessResult(lresponse, "Login successful");
        }

        public async Task<bool> ValidateSessionAsync(Guid sessionId)
        {

            return await _sessionRepository.ValidateSessionAsync(sessionId);
        }
    }
}