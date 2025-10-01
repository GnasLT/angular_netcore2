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

        public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request, string ipAddress, string userAgent)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                return await Result<LoginResponse>.FailureResult("User not found");
            if (user.PasswordHash != request.Password)
                return await Result<LoginResponse>.FailureResult("Invalid credentials");

            Sessions check = await _sessionRepository.GetByUserIdAsync(user.Id);
            LoginResponse lresponse = new LoginResponse()
            {
                Email = user.Email,
                Role = user.Role
            };
            if (check == null || check.ExpiresAt < DateTime.UtcNow)
            {
                if (check != null && check.ExpiresAt < DateTime.UtcNow)
                    await _sessionRepository.DeleteSessionAsync(check.Id);

                check = await _sessionRepository.CreateSessionAsync(user.Id, ipAddress, userAgent);
            }
            lresponse.SessionId = check.Id;
            return await Result<LoginResponse>.SuccessResult(lresponse, "Login successful");
        }

        public async Task<LoginResponse> ValidateSessionAsync(Guid sessionId, string ip, string agent)
        {
            var session = await _sessionRepository.GetByIdAsync(sessionId);
            if (session == null) return null;
            if (session.ExpiresAt < DateTime.UtcNow)
            {
                await _sessionRepository.DeleteSessionAsync(session.Id);
                return null;
            } 

            if (session.ipaddress != ip || session.useragent != agent) return null;

            await _sessionRepository.ExtendTime(session.Id);
            return new LoginResponse
            {
                SessionId = session.Id,
                Email = session.User.Email,
                Role = session.User.Role
            };
        }

        public async Task<Result<object?>> LogoutAsync(Guid sessionId)
        {
            await _sessionRepository.DeleteSessionAsync(sessionId);



            return await Result<object>.ReturnMessage(200, "Logout successfully");
        }
    }
}