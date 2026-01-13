using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.User.CreateUser
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.ToEntity();
            var idUserCreated = await _repository.CreateUser(user);

            return ResultViewModel<int>.Success(idUserCreated);
        }
    }
}
