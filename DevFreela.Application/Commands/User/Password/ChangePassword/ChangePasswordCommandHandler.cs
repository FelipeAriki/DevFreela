using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;
using DevFreela.Infrastructure.Notifications;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace DevFreela.Application.Commands.User.Password.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ResultViewModel>
    {
        private readonly IUserRepository _repository;
        private readonly IEmailService _emailService;
        private readonly IMemoryCache _memoryCache;
        private readonly IAuthService _authService;

        public ChangePasswordCommandHandler(IUserRepository repository, IEmailService emailService, IMemoryCache memoryCache, IAuthService authService)
        {
            _repository = repository;
            _emailService = emailService;
            _memoryCache = memoryCache;
            _authService = authService;
        }

        public async Task<ResultViewModel> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var cacheKey = $"RecoveryCode:{request.Email}";

            if (!_memoryCache.TryGetValue(cacheKey, out string? code) || code != request.Code)
                return ResultViewModel.Error("Oops...erro ao realizar troca de senha.");

            _memoryCache.Remove(cacheKey);

            var user = await _repository.GetUserByEmail(request.Email);

            if (user is null)
                return ResultViewModel.Error("Oops...erro ao realizar troca de senha.");

            var hash = _authService.ComputeHash(request.NewPassword);

            user.UpdatePassword(hash);
            await _repository.UpdateUser(user);

            return ResultViewModel.Success();
        }
    }
}
