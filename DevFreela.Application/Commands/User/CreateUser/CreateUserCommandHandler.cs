using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;
using MediatR;

namespace DevFreela.Application.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _repository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<ResultViewModel<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var hash = _authService.ComputeHash(request.Password);

            var user = request.ToEntity(hash);
            var idUserCreated = await _repository.CreateUser(user);

            return ResultViewModel<int>.Success(idUserCreated);
        }
    }
}
