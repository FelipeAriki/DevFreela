using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Notifications;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace DevFreela.Application.Commands.User.Password.PasswordRecovery
{
    public class PasswordRecoveryCommandHandler : IRequestHandler<PasswordRecoveryCommand, ResultViewModel>
    {
        private readonly IUserRepository _repository;
        private readonly IEmailService _emailService;
        private readonly IMemoryCache _memoryCache;

        public PasswordRecoveryCommandHandler(IUserRepository repository, IEmailService emailService, IMemoryCache memoryCache)
        {
            _repository = repository;
            _emailService = emailService;
            _memoryCache = memoryCache;
        }

        public async Task<ResultViewModel> Handle(PasswordRecoveryCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByEmail(request.Email);

            if (user is null)
                return ResultViewModel.Error("Erro ao solicitar recuperação de senha.");

            var code = new Random().Next(100000, 999999).ToString();

            var cacheKey = $"RecoveryCode:{request.Email}";

            _memoryCache.Set(cacheKey, code, TimeSpan.FromMinutes(10));

            await _emailService.SendAsync(user.Email, "Código de Recuperação", $"Seu código de recuperação é: {code}");

            return ResultViewModel.Success();
        }
    }
}
